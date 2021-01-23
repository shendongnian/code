    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
    
                    OutputCacheAttribute cache = new OutputCacheAttribute();
                      //set other properties
                    filters.Add(cache);
    }
