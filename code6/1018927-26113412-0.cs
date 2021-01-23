    public static DateTime GetCachedMethod(int nbMonth, NonDecoratedClass repo)
        {
            var methodCacheKey = "Test";
            DateTime obj = new DateTime();
            if (!cache.ContainsKey(methodCacheKey))
            {
                lock (zeLock)
                {
                    if (!cache.ContainsKey(methodCacheKey))
                    {
                        obj = repo.GetDateTimeAndMonth(nbMonth);
                        if (obj != null)
                        {
                            cache.Add(methodCacheKey, obj);
                        }
                    }
                }
            }
            else
            {
                obj = (DateTime)cache[methodCacheKey];
                
            }
            return obj;
        }
