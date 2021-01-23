    // Serialization:
    private string DictionaryToJson(IDictionary<string, int> dictionary)
    {
        return JsonConvert.SerializeObject(dictionary, Formatting.Indented);
    }
    
    // Disearilization:
    private Dictionary<string, int> JsonToDictionary(string json)
    {
        return JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
    }
