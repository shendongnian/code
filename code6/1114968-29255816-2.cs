    public DataType GetData(string domainName)
    {
        // Use the domain name as the key (or part of the key)
        var key = domainName;
    
        // Retrieve the data from the cache (System.Web.Caching shown)
        DataType data = HttpContext.Current.Cache[key];
        if (data == null)
        {
            // If the cached item is missing, retrieve it from the source
            data = GetDataFromDataSource();
            // Populate the cache, so the next request will use cached data
            // Note that the 3rd parameter can be used to specify a 
            // dependency on a file or database table so if it is updated, 
            // the cache is invalidated
            HttpContext.Current.Cache.Insert(
                key, 
                data, 
                null, 
                System.Web.Caching.Cache.NoAbsoluteExpiration, 
                TimeSpan.FromMinutes(10), 
                System.Web.Caching.CacheItemPriority.NotRemovable);
        }
        return data;
    }
    // Usage
    var data = GetData(HttpContext.Current.Request.Url.DnsSafeHost);
    
