    // returns the memory consumption of this process
    //  This includes active objects, objects to be disposed, and items within cache.
    //  Setting the parameter to 'true' will force a garbage collection before returning the results
    GC.GetTotalMemory(false);
    // This shows the maximum size available to the cache
    //  These limits can be set within the app.config / web.config files
    Cache.EffectivePrivateBytesLimit;
