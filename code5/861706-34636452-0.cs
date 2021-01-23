    public static IEnumerable<string> GetExtensions(this string mimeType)
    {
        var mappingDictionaryField = typeof(MimeMapping).GetField("_mappingDictionary", BindingFlags.NonPublic | BindingFlags.Static);
        if (mappingDictionaryField == null)
            return new string[0];
        // get the internal dictionary used for mime type lookup
        var mappingDictionary = mappingDictionaryField.GetValue(null); 
        if (mappingDictionary == null)
            return new string[0];
        // get type that owns the populate method and populated dictionary
        var dictionaryType = mappingDictionary.GetType().BaseType;
        if (dictionaryType == null)
            return new string[0];
        var populateMethod = dictionaryType.GetMethod("PopulateMappings", BindingFlags.NonPublic | BindingFlags.Instance);
        if (populateMethod == null)
            return new string[0];
        populateMethod.Invoke(mappingDictionary, null); 
        // get the populated mapping dictionary
        var mappingField = dictionaryType.GetField("_mappings", BindingFlags.Instance | BindingFlags.NonPublic);
        if (mappingField == null)
            return new string[0];
        var mapping = mappingField.GetValue(mappingDictionary) as IDictionary<string, string>;
        if (mapping == null)
            return new string[0];
            
        var extensions = mapping.Where(x => x.Value == mimeType)
                                .Select(x => x.Key);
        return extensions;
    }
