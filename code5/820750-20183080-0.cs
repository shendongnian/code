	for (int r = 0; r < numbers.GetLength(0); ++r)
	{
		for (int c = 0; c < numbers.GetLength(1); ++c)
		{
			Console.Write("{0,6} ", numbers[r, c]);
		}
		Console.WriteLine();
	}
