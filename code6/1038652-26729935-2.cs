	var entities = new BlockingCollection(new ConcurrentQueue<DataEntity>());
	
	// fill the collection with 10 items
	Parallel.For(0, limit, new ParallelOptions { MaxDegreeOfParallelism = 10 }, i =>
		{
			DataEntity x = entities.Take();
			DoWork(i, x);
			entities.Add(x);
		});
