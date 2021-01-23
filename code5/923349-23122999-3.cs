    public static string GetValue(string lookup)
    {
        string result;
        Data.TryGetValue(lookup, out result);
        return result;
    }
