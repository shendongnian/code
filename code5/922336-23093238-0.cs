	namespace ConsoleApplication1
	{
		public static class Arithmetic
		{
			public static int Add(int opreand1, int opreand2)
			{
				return opreand1 + opreand2;
			}
			public static int Subtract(int opreand1, int opreand2)
			{
				return opreand1 - opreand2;
			}
			public static int Multiply(int opreand1, int opreand2 )
			{
				return opreand1 * opreand2;
			}
			public static int Divide(int opreand1, int opreand2)
			{
				return opreand1 / opreand2;
			}
		}
		
		static void Main(string[] args)
        {
			Console.WriteLine ("1+1={0}\r\n2+2={1}\r\n3+3={2}\r\n4+4={3}\r\n",  
							Arithmetic.Add(1, 1), Arithmetic.Add(2,2), Arithmetic.Add(3,3), 
							Arithmetic.Add(4,4));
			Console.WriteLine("4-2={0}\r\n8-4={1}\r\n16-8={2}\r\n",
							Arithmetic.Subtract(4, 2), Arithmetic.Subtract(8, 4), 
							Arithmetic.Subtract(16, 8));
			Console.WriteLine("4*2={0}\r\n8*4={1}\r\n",
							Arithmetic.Multiply(4, 2), Arithmetic.Multiply(8, 4));
			Console.WriteLine("4%2={0}\r\n",
							Arithmetic.Divide(4, 2));
			Console.WriteLine("No. Add={0}\r\nNo. Subtract={1}\r\nNo. Multiply={2}\r\nNo. Divide={3}",
							Arithmetic.numAdd, Arithmetic.numSubtract, Arithmetic.numMutiply                           
							Arithmetic.numDivide);
			Console.ReadKey(); // to keep the console open until you press a key
		}
	}
