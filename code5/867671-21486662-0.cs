    Dictionary<char, string> wordMap = new Dictionary<char, string>();
    Dictionary<string, char> charMap = new Dictionary<string, char>();
    public void ConvertLookup ()
    {
        charMap = wordMap.ToDictionary(e => e.Value, e => e.Key);
    }
