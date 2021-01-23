    public void SetRowVariable(string key, object value)
    {
        var obj = new Dictionary<string, object>();
        obj[key] = value; // Of course you can put whatever crap you want here as long as your keys are unique
        string jsonString = JsonConvert.SerializeObject(obj);
        ...
    }
