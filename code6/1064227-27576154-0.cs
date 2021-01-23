    // this cache is probably going to be the application level cache in asp.net
    // but using Dictionary as an example in this case
    Dictionary<string,TranslationResult> cache = new ...
    private static object syncRoot = new Object();
    if (!cache.ContainsKey(key)
    {
        lock(syncRoot)
        {
            // this double checks is not a mistake.
            // the second request would check for existence of
            // the key once it acquire the lock
            if (!cache.ContainsKey(key) {
                // send request to google then store the result 
            }
            else {
                return cache[key];
            }
        }
    }
    else
    {
        return cache[key];
    }
