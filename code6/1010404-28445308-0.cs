    response.Cache.SetNoStore(); // assign no-store
    BindingFlags hiddenItems = BindingFlags.NonPublic | BindingFlags.Instance;
    var httpCachePolicyWrapper = response.Cache.GetType(); // HttpCachePolicyWrapper type
    
    var httpCache = httpCachePolicyWrapper.InvokeMember("_httpCachePolicy", BindingFlags.GetField | hiddenItems, null, response.Cache, null);
    var httpCachePolicy = httpCache.GetType(); // HttpCachePolicy type
    // Reset Cache Policy to Default    
    httpCachePolicy.InvokeMember("Reset", BindingFlags.InvokeMethod | hiddenItems, null, httpCache, null);
    var resetAllCachePolicy = httpCachePolicy.InvokeMember("_noStore", BindingFlags.GetField | hiddenItems, null, httpCache, null);
    
    response.Cache.SetNoStore(); // assign no-store
    // Undo SetNoStore Cache Policy
    httpCachePolicy.InvokeMember("_noStore", BindingFlags.SetField | hiddenItems, null, httpCache, new object[] { false });
    var resetNoStoreOnly = httpCachePolicy.InvokeMember("_noStore", BindingFlags.GetField | hiddenItems, null, httpCache, null);
