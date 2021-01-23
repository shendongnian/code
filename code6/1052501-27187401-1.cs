    using System;
    using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks;  
    namespace ConsoleApplication1
	{
	class Program
		{
		static void Main(String[] args)
			{
			int Option;
			int Num3, Num4;
			Num3=1;
			Num4 = 3;
			DisplayMenu();
			Option = GetUserOption();
			while (Option != 0)
				{
				switch (Option)
					{
					case 1:
						Num1();
						break;
					case 2:
						Num2();
						break;
					case 3:
						Overall(Num3, Num4);
						break;
					}
				}
			}
		static void DisplayMenu()
			{
			Console.WriteLine("1. Num1 2.Num2 3.Overall");
			}
		static int GetUserOption()
			{
			int Option;
			Console.WriteLine("Pick choice");
			Option = Convert.ToInt32(Console.ReadLine());
			return Option;
			}
		static int Num1()
			{
			int Num3;
			Console.WriteLine("Enter your first number");
			Num3 = Convert.ToInt32(Console.ReadLine());
			return Num3;
			}
		static int Num2()
			{
			int Num4;
			Console.WriteLine("Enter your second number");
			Num4 = Convert.ToInt32(Console.ReadLine());
			return Num4;
			}
		public static int Overall(int Num3, int Num4)
			{
			int Overall=0;
			Console.WriteLine("This will add the two together");
			Overall = Overall + Num3 + Num4;
			Console.WriteLine(Overall);
			return Overall;
			}
		}
	}
