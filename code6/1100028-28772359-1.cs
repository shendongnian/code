    MemoryCache cache = MemoryCache.Default;
    string baseCacheKey = "Users";
    public void DoSomethingWithUsers(int userId)
    {
        var cacheKey = baseCacheKey + userId.ToString();
        if (!cache.Contains(cacheKey))
        {
            RefreshUserCache(userId);
        }
        var users = cache.Get(cacheKey) as List<User>
        // You can do something with the users here
    }
    public static RefreshUserCache(int userId)
    {
        var users = ws.SelectUsers();
        var cacheItemPolicy = new CacheItemPolicy();
        cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1);
        var cacheKey = baseCacheKey + userId.ToString();
        cache.Add(cacheKey, users , cacheItemPolicy);
    }
