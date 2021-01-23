    public void Set(string key, string value)
    {
        string obj = mapping[key];  // obj points to the string value at mapping[key]
        obj = value;                // obj points to the string value referenced by value - mapping[key] is unchanged.
    }
