    public BaseController() : base() 
    {
        CacheItemPolicy policy = new CacheItemPolicy();
        policy.AbsoluteExpiration = DateTime.UtcNow.AddMinutes(10);
    
        MemoryCache.Default.Add(Guid.NewGuid(), "RequestCount", policy);
    }
    public int RequestCountPerMinute
    {
        get
        {
            return MemoryCache.Default
               .Where(kv => kv.Value.ToString() == "RequestCount").Count() / 10;
        }
    }
