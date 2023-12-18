using System;
using System.Collections.Generic;

class Veiculo
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public DateTime HoraEntrada { get; set; }
}

class Estacionamento
{
    private List<Veiculo> veiculosEstacionados;

    public Estacionamento()
    {
        veiculosEstacionados = new List<Veiculo>();
    }

    public void AdicionarVeiculo(Veiculo veiculo)
    {
        veiculo.HoraEntrada = DateTime.Now;
        veiculosEstacionados.Add(veiculo);
        Console.WriteLine($"Veículo {veiculo.Placa} adicionado ao estacionamento.");
    }

    public void RemoverVeiculo(string placa)
    {
        Veiculo veiculo = veiculosEstacionados.Find(v => v.Placa == placa);
        if (veiculo != null)
        {
            DateTime horaSaida = DateTime.Now;
            TimeSpan tempoEstacionado = horaSaida - veiculo.HoraEntrada;
            double valorCobrado = CalcularValor(tempoEstacionado);
            Console.WriteLine($"Veículo {veiculo.Placa} removido. Valor cobrado: R${valorCobrado:F2}");
            veiculosEstacionados.Remove(veiculo);
        }
        else
        {
            Console.WriteLine($"Veículo com placa {placa} não encontrado no estacionamento.");
        }
    }

    public void ListarVeiculos()
    {
        Console.WriteLine("Veículos estacionados:");
        foreach (Veiculo veiculo in veiculosEstacionados)
        {
            Console.WriteLine($"{veiculo.Placa} - {veiculo.Marca} {veiculo.Modelo}");
        }
    }

    private double CalcularValor(TimeSpan tempoEstacionado)
    {
        // Exemplo de cálculo de valor: R$ 2 por hora
        double valorPorHora = 2.0;
        double totalHoras = tempoEstacionado.TotalHours;
        return valorPorHora * totalHoras;
    }
}

class Program
{
    static void Main()
    {
        Estacionamento estacionamento = new Estacionamento();

        Veiculo veiculo1 = new Veiculo { Placa = "ABC1234", Marca = "Toyota", Modelo = "Corolla" };
        Veiculo veiculo2 = new Veiculo { Placa = "XYZ5678", Marca = "Honda", Modelo = "Civic" };

        estacionamento.AdicionarVeiculo(veiculo1);
        estacionamento.AdicionarVeiculo(veiculo2);

        estacionamento.ListarVeiculos();

        // Simulando a passagem de 2 horas
        veiculo1.HoraEntrada = veiculo1.HoraEntrada.AddHours(-2);

        estacionamento.RemoverVeiculo("ABC1234");

        estacionamento.ListarVeiculos();
    }
}
