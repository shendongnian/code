    public IReadOnlyDictionary<Int64, Boolean> GetSettings()
    {
       // Just return the dictionary with property type IReadOnlyDictionary`2 but
       // then evil callers can still do the following.
       // ((Dictionary<Int64, Boolean>)coolObject.GetSettings()).Clear();
       return this._objectSettings;
    }
