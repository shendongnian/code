    ObjectCache _cache = MemoryCache.Default;
    static object _lockObject = new object();
    public Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> func, TimeSpan? cacheExpiration = null) where T : class
	{
		var task = (T)_cache[cacheKey];
		if (task != null) return task;			
		lock (_lockObject)
		{
			task = (T)_cache[cacheKey];
			if (task != null) return task;
			task = func();
			Set(cacheKey, task, cacheExpiration);
			task.ContinueWith(t => {
				if (t.Status != TaskStatus.RanToCompletion)
					_cache.Remove(cacheKey);
			});
		}
		return task;
	}i
