    using System;
	using System.IO.Ports;
	namespace SerialPortTest
	{
		class Program
		{
			static void Main(string[] args)
			{
				var p = new SerialPort(args[0], 9600, Parity.None, 8, StopBits.One);
				p.Open();
				Console.WriteLine("Sending ({1}) {0}", args[1], args[1].Length);
				p.WriteLine(args[1]);
				
				Console.WriteLine("Reading back");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(p.ReadLine());
				Console.ResetColor();
			}
		}
	}
