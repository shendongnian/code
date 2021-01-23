    public string Run(bool enableLocalProcessing)
    		{
    			double sum = 0.0;
    			double step = 1.0 / (double)Steps;
    			/* ORIGINAL VERSION
    			object obj = new object();
    
    			Parallel.ForEach(
    				Partitioner.Create(0, Steps),
    				() => 0.0,
    				(range, state, partial) =>
    				{
    					for (long i = range.Item1; i < range.Item2; i++)
    					{
    						double x = (i - 0.5) * step;
    						partial += 4.0 / (1.0 + x * x);
    					}
    					return partial;
    				},
    				partial => { lock (obj) sum += partial; });
    			*/
    			sum = Enumerable
    				.Range(0, Steps)
    				// Create bucket
    				.GroupBy(s => s / 50)
    				// Local variable initialization is not distributed over the grid
    				.Select(i => new 
    				{
    					Item1 = i.First(),
    					Item2 = i.Last() + 1, // Inclusive
    					Step = step
    				})
    				.AsParallelGrid(data =>
    				{
    					double partial = 0;
    					for (var i = data.Item1; i != data.Item2 ; ++i)
    					{
    						double x = (i - 0.5) * data.Step;
    						partial += (double)(4.0 / (1.0 + x * x));
    					}
    					return partial;
    				}, new GridSettings()
    				{
    					EnableLocalProcessing = enableLocalProcessing
    				})
    				.Sum() * step;
    			return sum.ToString();
    			 
    		}
