    static string GetFirstKeyFromValue(Dictionary<string,string> dict, string val)
    {
        if(!dict.ContainsValue(val))
            return null; //return null because nothing matched.
        return dict.FirstOrDefault(kv => kv.Value.Equals(val)).Key;
    }
