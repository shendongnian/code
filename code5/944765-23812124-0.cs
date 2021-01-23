    protected Dictionary<string, object> coll = new Dictionary<string, object>();
    public object this[string key]
    {
        get
        {
            if(coll.ContainsKey(key) == false)
                coll.Add(key, this.CreateObjectForDictionary(key))
            return coll[key];
        }
    }
