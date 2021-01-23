    public Dictionary<Int64, Boolean> GetSettings()
    {
       // Return a snapshot of the current settings.
       return new Dictionary<Int64, Boolean>(this._objectSettings);
    }
    public ReadOnlyDictionary<Int64, Boolean> GetSettings()
    {
       // Return a read-only wrapper around the current settings.
       return new ReadOnlyDictionary<Int64, Boolean>(this._objectSettings);
    }
