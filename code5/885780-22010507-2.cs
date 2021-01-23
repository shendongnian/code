	async Task RunAll()
	{
	    var tasks = new List<Task>();
	
		if (sameCondOne)
		{
			await RunDataOneAsymc();
		}
	
		// ...
	
		if (sameCondN)
		{
			await RunDataNAsymc();
		}
	
		await Task.WhenAll(tasks);
	}
