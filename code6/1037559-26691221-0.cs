	static double EnterNumber(string descr)
	{
		while (true)
		{
			try
			{
				Console.WriteLine(descr);
				var value = Convert.ToDouble(Console.ReadLine());
				return value;
			}
			catch (FormatException)
			{
				// just try again
			}
		}
	}
	static char EnterOperator(string descr)
	{
		while (true)
		{
			try
			{
				Console.WriteLine(descr);
				var op = Convert.ToChar(Console.ReadLine());
				if( ("+-*/").IndexOf(op) >= 0)
					return op;
			}
			catch (FormatException)
			{
				// just try again
			}
		}
	}
	static void Calculate(double val1, char op, double val2)
	{
		switch (op)
		{
			case '+':
				Console.WriteLine(val1 + val2);
				break;
			case '-':
				Console.WriteLine(val1 - val2);
				break;
			case '*':
				Console.WriteLine(val1 * val2);
				break;
			case '/':
				Console.WriteLine(val1 / val2);
				break;
			default: 
				Console.WriteLine("Unhandled operator "+op);
				break;
		}
	}
