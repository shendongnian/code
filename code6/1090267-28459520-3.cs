    public static void addDictionarySession(
      Dictionary<string, List<string>> sessionDict, string key, string value)
    {
      List<string> stringValue = new List<string>() { value };      
      sessionDict.Add(key, stringValue);
    }
