    public Dictionary<int, object> GetDictionary(string KeyName, List<object> list)
    {
        return list.ToDictionary(v => GetPropValue(v, KeyName));
    }
        
