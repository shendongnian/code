	public override void Configure(Container container)
	{
		...
		try
		{
			var redisManager = new PooledRedisClientManager("localhost:6379");
			// do some sort of test to see if we can talk to the redis server
			var client = redisManager.GetCacheClient();
			var fakeKey = "_________test_______";
			client.Add(fakeKey, 1);
			client.Remove(fakeKey);
                        // if it worked register the cacheClient
			container.Register(c => redisManager.GetCacheClient()).ReusedWithin(ReuseScope.None);
		}
		catch (Exception ex)
		{
			// fall back to in memory cache
			// Log some sort of warning here.
			container.Register<ICacheClient>(c => new MemoryCacheClient());
		}
		...
	}
