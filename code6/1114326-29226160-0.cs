	static void Main()
	{
		var sum =
			Enumerable
				.Range(0, ARRAYSIZE)
				.Select(n =>
				{
					Console.WriteLine("Please enter the score of each test:");
					return int.Parse(Console.ReadLine());
				})
				.Sum();
				
		Console.WriteLine();
		Console.WriteLine("The sum is:");
		Console.WriteLine(sum);
	}
