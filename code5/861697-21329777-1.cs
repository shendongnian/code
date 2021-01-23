    // My cache, handle it the way you like
    private static DataCache _cache;
    
    public static void ClearCache()
    {
        Parallel.ForEach(_cache.GetSystemRegions(), region =>
        {
             _cache.ClearRegion(region);
             var sysRegion = _cache.GetSystemRegionName(region);
             _cache.ClearRegion(sysRegion);
         });
     }
