    public class TheCache
    {
        // Set the cache
        public static void SetCache(string key, object data, DateTime time)
        {
            MemoryCache.Default.Set(key, data, time);
        }
        // Get the cache
        public static object GetCache(string key)
        {
            return MemoryCache.Default.Get(key);
        }
    }
