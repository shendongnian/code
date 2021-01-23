	var sw = Stopwatch.StartNew();
	var x = 0L;
	for (var y = 0; y < 1000000000L; y++)
	{
		{
			x += y;
		}
	}
	sw.Stop();
	Console.WriteLine(x);
	Console.WriteLine(sw.ElapsedMilliseconds);
