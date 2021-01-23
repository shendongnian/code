    static List<string> GetKeysFromValue(Dictionary<string,string> dict, string val)
    {
        if(!dict.ContainsValue(val))
            return new List<string>(); //return EMPTY list for no matching keys
        return dict.Where(kv => kv.Value.Equals(val)).Select(kv => kv.Key).ToList();
    }
