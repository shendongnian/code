    public static class CacheManager
    {
        private static CacheEntryRemovedCallback callback = null;
        public delegate void CacheExpiredHandler(string key);
        public static event CacheExpiredHandler CacheExpired;
        static CacheManager()
        {
            // create the callback when the cache expires.
            callback = new CacheEntryRemovedCallback(MyCachedItemRemovedCallback);
        }
        private static void MyCachedItemRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            if (CacheExpired != null)
                CacheExpired(arguments.CacheItem.Key);
        }
    public static class DataManager
    {
        static DataManager()
        {
            // when a cached list expires, notify me with the key of the list.
            CacheManager.CacheExpired += new CacheManager.CacheExpiredHandler(CacheManager_CacheExpired);
            
        }
        /// <summary>
        /// When a chached list expires, this is the callback method that is called.
        /// </summary>
        /// <param name="key">The key of the list that just expired.</param>
        static void CacheManager_CacheExpired(string key)
        {
            // Do something now because the cache manager has raised an event that it has expired.
        }
