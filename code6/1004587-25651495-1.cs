	if (Multithread)
	{
		ParallelOptions pOptions = new ParallelOptions();
		pOptions.MaxDegreeOfParallelism = Environment.ProcessorCount;
		Parallel.For(0, FileNames.Length, pOptions, i => Solve(FileNames[i]));
	}
	else
	{
		foreach (string s in FileNames)
		{
			Solve(s);
		}
	}
