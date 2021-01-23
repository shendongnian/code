	private static void Main(string[] args)
	{
		var inputAmount = 4500;
		var intervals = new[] {100, 500, 1000};
		if (inputAmount%100 != 0)
		{
			Console.Write("Only bills of in increments of 100 are dispensed");
			return;
		}
		foreach (var interval in intervals.OrderByDescending(e => e))
		{
			int count = inputAmount/interval;
			inputAmount = inputAmount%interval;
			Console.WriteLine("{0} {1} Note", count, interval);
		}
		Console.Read();
	}
