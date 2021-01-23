    void Application_Start(object sender, EventArgs e)
    {
        AddTask("DoStuff", 30); // 30 seconds
    }
    
    private static CacheItemRemovedCallback OnCacheRemove;
    
    private void AddTask(string name, int seconds)
    {
        OnCacheRemove = CacheItemRemoved;
    
        HttpRuntime.Cache.Insert(name, seconds, null, 
            DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
            CacheItemPriority.NotRemovable, OnCacheRemove);
    }
    
    public void CacheItemRemoved(string k, object v, CacheItemRemovedReason r)
    {
        // Checks if a value from database is true. 
        // If so, call to your method here ...
    
        AddTask(k, Convert.ToInt32(v));
    }
