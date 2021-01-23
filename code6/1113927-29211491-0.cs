    static List<string> GetKeysFromValue(Dictionary<string,string> dict, string val)
    {
        if(!dict.ContainsValue(val))
            return null;
        return dict.Where(kv => kv.Value.Equals(val)).Select(kv => kv.Key).ToList();
    }
    static string GetFirstKeyFromValue(Dictionary<string,string> dict, string val)
    {
        if(!dict.ContainsValue(val))
            return false;
        return dict.FirstOrDefault(kv => kv.Value.Equals(val)).Key;;
    }
