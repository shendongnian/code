    public static Dictionary<string, T> ToCaseInsensitive<T>(this Dictionary<string, T> caseSensitiveDictionary)
    {
        var caseInsensitiveDictionary = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
        caseSensitiveDictionary.Keys.ToList()
            .ForEach(k => caseInsensitiveDictionary[k] = caseSensitiveDictionary[k]);
    
        return caseInsensitiveDictionary;
    }
