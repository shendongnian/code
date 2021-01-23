    static Dictionary<string, char> charMap;
    public static void ConvertLookup ()
    {
        charMap = wordMap.ToDictionary(e => e.Value, e => e.Key);
    }
