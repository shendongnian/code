    public IEnumerable<string> GetPathsFromConfig()
    {
      var xdoc = XDocument.Load(ConfigurationManager
        .OpenExeConfiguration(ConfigurationUserLevel.None)
        .FilePath);
      var paths = xdoc.Descendants("Paths")
        .Descendants("path")
        .Select(x => x.Value);
      return paths
    }
