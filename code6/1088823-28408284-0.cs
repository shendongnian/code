    public class TheCache
    {
        #region Instance
        private static TheCache caches;
        private TheCache() { }
        public static TheCache Instance
        {
            get
            {
                if (null == caches)
                    caches = new TheCache();
                return caches;
            }
        }
        #endregion
        // Set the cache
        public void SetCache(string key, object data, DateTime time)
        {
            MemoryCache.Default.Set(key, data, time);
        }
        // Get the cache
        public object GetCache(string key)
        {
            return MemoryCache.Default.Get(key);
        }
    }
