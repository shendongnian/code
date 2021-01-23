	void Main()
	{
		bool runTimeParallelOption = true; // assume this option comes from e.g. user/config
	
		var j = Enumerable.Range(1,5);
		
		var results = Enumerable.Empty<int>().Select(x => new { Number = (int)0, Square = (int)0 }).Take(0);
		
		var mutate = InferredProjection(1, results.FirstOrDefault(),  x => { Thread.Sleep(1000); return new { Number = x, Square = x * x }; });
		
		var sw = Stopwatch.StartNew();
		if (runTimeParallelOption)
			results = j.AsParallel().Select(mutate);
		else
			results = j.Select(mutate);
		sw.Stop();
		
		foreach (var result in results)
			Console.WriteLine(result.Square);
			
		Console.WriteLine("Elapsed: : " + sw.Elapsed);
	}
	
	
	static Func<T, U> InferredProjection<T, U>(T infer1, U infer, Func<T, U> project)
	{
		return project;
	}
