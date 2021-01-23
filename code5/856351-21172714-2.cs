    public Dictionary<string, string> GetSettings(string path)
    {
    
      var document = XDocument.Load(path);
      var root = document.Root;
      var results =
        root
          .Elements()
          .ToDictionary(element => element.Name.ToString(), element => element.Value);
      return results;
    }
