    private ConcurrentDictionary<string,bool> lockMap;
    public RefreshData(string key, Func<string, bool> cacheMissAction)
    {
        if (!lockMap.TryAdd(key, true))
        {
            return;
        }
        // if you are here means task was not already present
        cacheMissAction(key);
        lockMap.Remove(key);
    }
