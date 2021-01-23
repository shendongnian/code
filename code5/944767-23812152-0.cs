    Dictionary <string,object> coll = new Dictionary <string,object> ();
    public object GetCollValue(string key)
    {
        if (!coll.ContainsKey(key))
        {
            //logic for "not exists"
        }
        var value = coll[key];
        if (value == null)
        {
            //logic for "is null"
        }
        return value;
    }
