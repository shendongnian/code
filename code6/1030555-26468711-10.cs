    private ConcurrentDictionary<string, object> lockDict = new ConcurrentDictionary<string, object>();
    private object GetLock([CallerMemberName] string name)
    {
        return lockDict.GetOrAdd(name,
            (key) => new object());    // Using a lambda here prevents evaluation each time the dictionary is queried
    }
    ...
    private string _someProperty;
    public string SomeProperty
    {
        get { lock(GetLock()) return _someProperty; }
        set { lock(GetLock()) _someProperty = value; }
    }
