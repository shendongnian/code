    public static class CacheHelper<T>
    {
        public static void AddCacheItem(string rawKey, object value)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.SlidingExpiration = TimeSpan.FromMinutes(10);
    
            System.Runtime.Caching.MemoryCache.Default.Set(HttpContext.Current.Session.SessionID.ToString() + rawKey, value, policy);
        }
    
        public static T GetCacheItem(string rawKey)
        {
            return (T)MemoryCache.Default.Get(GetCacheKey(rawKey));
        }
    }
 
