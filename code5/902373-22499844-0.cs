    public static class AgencyCacheManager
    {
    	private static MemoryCache _cache = MemoryCache.Default;
    
    	public static List<RefAgency> ListAgency
    	{
    		get
    		{
    			if (!_cache.Contains("ListAgency"))
    				RefreshListAgency();
    			return _cache.Get("ListAgency") as List<Agency>;
    		}
    	}
    
    	public static void RefreshListAgency()
    	{
    		var listAgency = GetAllComplete();
    
    		CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
    		cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(1);
    
    		_cache.Add("ListAgency", listAgency, cacheItemPolicy);
    	}
    }
