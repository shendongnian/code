	Func<Func<bool>, int> work = cancelling =>
	{
		for (var i = 0; i < 100; i++)
		{
			Thread.Sleep(10); //1000 ms in total
			if (cancelling())
			{
				Console.WriteLine("Cancelled on {0}", i);
				return -1;
			}
		}
		Console.WriteLine("Done");
		return 42;
	};
