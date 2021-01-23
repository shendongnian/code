    public static async Task Test()
	{
		var tasks = new List<Task>();
		tasks.Add(PrintNumber(1));
		tasks.Add(PrintNumber(2));
		tasks.Add(PrintNumber(3));
		Console.WriteLine("This should be written first..");
		// This should be printed last..
		await Task.WhenAll(tasks);
	}
	public static async Task PrintNumber(int number)
	{
		await Task.Yield();
		Console.WriteLine(number);
	}
