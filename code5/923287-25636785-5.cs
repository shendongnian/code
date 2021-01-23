    public BaseController() : base() 
    {
        CacheItemPolicy policy = new CacheItemPolicy();
        policy.AbsoluteExpiration = DateTime.UtcNow.AddMinutes(20);
        MemoryCache.Default.Add(System.Web.HttpContext.Current.Request.UserHostAddress, "User", policy);
    }
