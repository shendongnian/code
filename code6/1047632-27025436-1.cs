    public static void Store(IDictionary<string, string> d, string filename)
    {
        new XElement("root", d.Select(kv => new XElement(kv.Key, kv.Value)))
                    .Save(filename, SaveOptions.OmitDuplicateNamespaces);
    }
     public static IDictionary<string, string> Retrieve(string filename)
    {
        return XElement.Parse(File.ReadAllText(filename))
                       .Elements()
                       .ToDictionary(k => k.Name.ToString(), v => v.Value.ToString());
    }
