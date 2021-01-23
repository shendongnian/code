	public static dynamic LoadFromCache(string cacheKey, int secondsToCache, Func<object> query)
	{
		object tocache = null;
		// result will always get the value here
		// tocache will only have the value when it was pulled from our method
		object result = MemoryCache.Default[cacheKey] ?? (tocache = query.Invoke());
		if (secondsToCache > 0)
		{
			// If this came from Massive, we need to get the list instead of opening a 
			// database connection each time we enumerate.  I check the type, because other things
			// are stored.
			if (tocache is IEnumerable<dynamic>)
			{
				tocache = ((IEnumerable<dynamic>)tocache).ToList<dynamic>();
				result = tocache;
			}
			if (tocache != null) // only save to cache if it wasn't there
				MemoryCache.Default.Add(cacheKey, tocache, DateTime.UtcNow.AddSeconds(secondsToCache));
		}
		else
		{
			// remove from cache only if secondsToCache was zero or less
			MemoryCache.Default.Remove(cacheKey);
		}
		return result;
	}
