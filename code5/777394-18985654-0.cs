    private readonly IDictionary<string,object> _readonlyCache;
    private IDictionary<string,object> ReadOnlyCache
    {
        get
        {
            return _readonlyCache ?? _readonlyCache = GetEmptyCache();
        }
    }
    protected abstract IDictionary<string,object> GetEmptyCache();
