	static void Main(string[] args)
	{
		int power = 2;
		Console.Write("disk:".PadLeft(8));
		for (int j = 1; j <= 5; j++)
			Console.Write(j.ToString().PadLeft(5));
		Console.WriteLine();
		Console.Write("moves:".PadLeft(8));
		for (int i = 1; i <= 5; i++)
			Console.Write(((long)Math.Pow(power, i) - 1).ToString().PadLeft(5));
		Console.WriteLine();
		Console.ReadLine();
	}
