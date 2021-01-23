    static void Main(string[] args)
		{
			string number = "1762483";
			int digit = 0;
			int sum = 0;
			for (int i = 0; i <= number.Length - 1; i++)
			{
				
				if (i % 2 == 1)
				{
					digit = int.Parse(number.Substring(i, 1));
					sum += DoubleDigitValue(digit);
					
					Console.WriteLine(digit);
				}
				else
				{
					digit = int.Parse(number.Substring(i, 1));
					sum += digit;
				}
			}
			Console.WriteLine(sum);
			if (sum % 10 == 0)
			{
				Console.WriteLine("valid");
			}
			else
			{
				Console.WriteLine("Invalid");
			}
		}
		static int DoubleDigitValue(int digit)
		{
			int sum;
			int doubledDigit = digit * 2; 
			if (doubledDigit >= 10)
			{
				sum = 1 + doubledDigit % 10;
			} else
			{
				sum = doubledDigit; 
			}
			return sum; 
		}
