	void Main()
	{
		//GetNumbers().Dump();
		var period = TimeSpan.FromSeconds(1);
		var scheduler = Scheduler.Default;
		var source = GetNumbers();
		Observable.Interval(period, scheduler)
				.Zip(source, (a,b)=>b)
				.Dump();
		
	}
	
	// Define other methods and classes here
	
	public IEnumerable<int> GetNumbers()
	{
		var i = 0;
		while (i<10)
		{
			DateTimeOffset.Now.ToString("o").Dump();
			yield return i++;
		}
	}
