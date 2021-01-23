    private static Dictionary<string, int> CountEnumOccurrence<TEnum>(
        Dictionary<TEnum, List<string>> valueSource)
    {
        var convertedDictionary = new Dictionary<string, int>();
    
        foreach (var entry in valueSource)
        {
            var name = Enum.GetName(entry.Key.GetType(), entry.Key);
            convertedDictionary.Add(name, entry.Value.Count);
        }
    
        return convertedDictionary;
    }
