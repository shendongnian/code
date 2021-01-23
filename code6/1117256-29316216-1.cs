	Console.WriteLine("Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N");
	Console.Write("N:");
	double n = double.Parse(Console.ReadLine());
	Console.Write("X:");
	double x = double.Parse(Console.ReadLine());
	double result = 1;
	int ifac = 1;
	for (int i = 1; i <= n; i++)
	{
        ifac = 1; //This line is very important
		for (int j = i; j >= 1; j--)
		{
			ifac *= j;
		}
		result += ifac / Math.Pow(x, i);
	}
	Console.WriteLine(result);
