    public static class MemoryCacheHelper
    {
        private static readonly MemoryCacheServiceProvider s_serviceProvider = new MemoryCacheServiceProvider();
        static MemoryCacheHelper()
        {
            try
            {
                ObjectCache.Host = s_serviceProvider;
            }
            catch (InvalidOperationException ex)
            {
                // ObjectCache.Host can only be set once.
            }
        }
        public static MemoryCache Create(string name, NameValueCollection config) 
        {
            return new MemoryCache(name, config);
        }
        // Return approximate cache size and when that value was last determined.
        public static Tuple<long, DateTime> GetApproximateSize(string name)
        {
            return s_serviceProvider.GetApproximateSize(cache.Name);
        }
        private class MemoryCacheServiceProvider : IMemoryCacheManager, IServiceProvider
        {
            private readonly object m_lock = new object();
            private readonly IDictionary<string, Tuple<long, DateTime>> m_sizes = new Dictionary<string, Tuple<long, DateTime>>();
            public Tuple<long, DateTime> GetApproximateSize(string name)
            {
                lock (m_lock)
                {
                    Tuple<long, DateTime> info;
                    if (m_sizes.TryGetValue(name, out info))
                        return info;
                    return null;
                }
            }
            void IMemoryCacheManager.UpdateCacheSize(long size, MemoryCache cache)
            {
                lock (m_lock)
                {
                    // The UpdateCacheSize() method will be called based on the configured "pollingInterval"
                    // for the respective cache. That value defaults to 2 minutes. So this statement doesn't
                    // fire to often and as a positive side effect we get some sort of "size-heartbeat" which
                    // might help when troubleshooting.
                    m_sizes[cache.Name] = Tuple.Create(size, DateTime.UtcNow);
                }
            }
            void IMemoryCacheManager.ReleaseCache(MemoryCache cache)
            {
                lock (m_lock)
                {
                    m_sizes.Remove(cache.Name);
                }
            }
            object IServiceProvider.GetService(Type serviceType)
            {
                if (serviceType == typeof(IMemoryCacheManager))
                {
                    return this;
                }
                return null;
            }
        }
