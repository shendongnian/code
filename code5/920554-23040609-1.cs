	for (int i=0; i<10; i++)
	{
		string line = Console.ReadLine();
		int value;
		if (Int32.TryParse(line, out value))
		{
		   a[i] = value;
		}
		else
		{
			// cannot parse it as an integer
		}
	}
