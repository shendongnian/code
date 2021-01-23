    public static class DictionaryExtensions
    { 
      public static string WriteContent(this Dictionary<string, string> source)
      {
        var sb = new StringBuilder();
        foreach (var kvp in source) {
          sb.AddLine("Key: {0} Value: {1}", kvp.Key, kvp.Value);
        }
        return sb.ToString();
      }
    }
