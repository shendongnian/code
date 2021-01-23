	public static IEnumerable<int> number()
	{
		Console.WriteLine("Enter your number!");
		string enter = Console.ReadLine();
		int digitSum = int.Parse(enter);
		foreach (var n in Enumerable.Range(0, 1000))
		{
			if (n.ToString().ToCharArray().Sum(c => c - '0') == digitSum)
			{
				yield return n;
			}
		}
	}
