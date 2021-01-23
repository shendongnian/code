    public static object Get(DataCache dataCache, string label, object obj)
            {
                try
                {
                    return  (object)dataCache.Get(label);
    
                }
                catch (DataCacheException)
                {
                    dataCache.Remove(label);
                }
    
                return null;
            }
