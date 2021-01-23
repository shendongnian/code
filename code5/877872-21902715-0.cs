        protected ObjectCache cache = MemoryCache.Default;
        protected T GetCacheOrExecute<T>(string key, Func<T> addToCacheFunction)
        {
            if (cache.Contains(key))
            {
                return (T)cache.Get(key);
            }
            else
            {
                T retValue = default(T);
                if (null != addToCacheFunction)
                {
                    retValue = addToCacheFunction();
                    var cachItem = new CacheItem(key, retValue);
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30); //The cache time out
                    cache.Add(cachItem, policy);
                }
                return retValue;
            }
        }
