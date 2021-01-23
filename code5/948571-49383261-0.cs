	long i
	{
		get { return Interlocked.Read(ref _i); }
		set { Interlocked.Exchange(ref _i, value); }
	}
	
	
	long _i;
	
	void Main()
	{
	
		Parallel.ForEach(Enumerable.Range(0, 1000_000), 
			//new ParallelOptions { MaxDegreeOfParallelism = 1},
			x=>
		{
			i++;
		});
		
		i.Dump();
	}
