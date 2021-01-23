    using System.Linq.XML;
    ...
    public static Dictionary<string, string> ConfigValues
        = XDocument.Load(configFilePath)
            .Root
            .Elements()
            .Where(e => e.Name == "add")
            .ToDictionary(
                e => e.Attributes().FirstOrDefault(a => a.Name == "key").Value.ToString(),
                e => e.Attributes().FirstOrDefault(a => a.Name == "value").Value.ToString());
