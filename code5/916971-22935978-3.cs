    Cache.Insert("data", "", null, DateTime.Now.AddMinutes(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, new CacheItemRemovedCallback(CacheRemovedCallback));
    public string CacheRemovedCallback(String key, object value, System.Web.Caching.CacheItemRemovedReason removedReason)
    {
        // here you can log, renew the value, etc...
    }
