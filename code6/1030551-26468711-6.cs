    private ConcurrentDictionary<string, object> lockDict = new ConcurrentDictionary<string, object>();
    private object GetLock([CallerMemberName] string name)
    {
        if(lockDict.Keys.Contains(name) == false)
            lockDict[name] = new object();
        return lockDict[name];
    }
    ...
    private string _someProperty;
    public string SomeProperty
    {
        get { lock(GetLock()) return _someProperty; }
        set { lock(GetLock()) _someProperty = value; }
    }
