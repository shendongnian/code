    // extension method
    public static Dictionary<string, string> Combine(this Dictionary<string, string> strs, Dictionary<int, int> ints)
    {
        foreach (var i in ints)
        {
            strs.Add(i.Key.ToString(), i.Value.ToString());
        }
        return strs;
    }
    // usage
    strs = strs.Combine(ints);
