    var cache = MemoryCache.Default;
    public void DoSomethingWithUsers()
    {
        if (!cache.Contains("Users"))
        {
            RefreshUserCache();
        }
        var users = cache.Get("Users") as List<User>
        // You can do something with the users here
    }
    public static RefreshUserCache()
    {
        var users = ws.SelectUsers();
        var cacheItemPolicy = new CacheItemPolicy();
        cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1);
        cache.Add("Users", users , cacheItemPolicy);
    }
