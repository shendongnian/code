    private static readonly object ActiveNull = new object();
    
    public bool GetIfPresent(string key, out object value)
    {
        object fromCache = Web.HttpContext.Current.Cache.Get(key);
        if(fromCache == null)
        {
          //failed to obtain.
          value = null;
          return false;
        }
        if(ReferenceEquals(fromCache, ActiveNull))
        {
          //obtained value representing null.
          value = null;
          return true;
        }
        value = fromCache;
        return true;
    }
    
    public void AddToCache(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
    {
      Web.HttpContext.Current.Cache.Add(key, value ?? ActiveNull, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
    }
