	using System;
	namespace Conv
	{
		public class Centimeter
		{
			public int cmvar;
			public Centimeter()
			{
				cmvar = 0;
			}
			public Centimeter(int mm)
			{
				cmvar = mm;
			}
			public int getMeterst()
			{
				return cmvar / 100;
			}
			public int Remainder()
			{
				return cmvar % 100;
			}
			public void Printout()
			{
				Console.WriteLine("{0} Meters and {1} Centimeters", this.getMeterst(), this.Remainder());
			}
		}
		public class MeterToCenti
		{
			public static void Main()
			{
				char choice;
				char n = 'n';
				do
				{
					Console.WriteLine("Do you want to continue? (y/n)");
					choice = Console.ReadKey().KeyChar;
					Console.WriteLine(); // for pure design needs
					Centimeter c = new Centimeter();
					Console.WriteLine("enter value in centimeters");
					c.cmvar = int.Parse(Console.ReadLine());
					c.Printout();
				}
				while (choice != n);
			}
		}
	}
