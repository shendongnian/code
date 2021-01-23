    int NumberOfLines = 5;
	int count = 1;
	while (NumberOfLines-- != 0)
	{
		int c = count;
		while (c-- != 0)
		{
			Console.Write("*");
		}
		Console.WriteLine();
		count = count + 2;
	}
    
