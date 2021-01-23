    using System.Runtime.Caching;
    public int UsersOnlineCount
    {
        get
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.UtcNow.AddMinutes(20);
            MemoryCache.Default.Add(Request.UserHostAddress, "User", policy);
            return MemoryCache.Default.Where(kv => kv.Value.ToString() == "User").Count();
        }
    }
