    public Dictionary<Tricks, List<Tricks>> Clumsy(XDocument doc)
    {
        var plistData =
            doc
                .Root
                .Element("dict")
                .Element("array")
                .Elements("dict")
                .Select( ele => new     
                    {
                        key = Parse(ele),
                        val = ele.Element("array")
                               .Elements("dict")
                               .Select(Parse).ToList()
                    }).ToDictionary(pair => pair.key,
                                    pair => pair.val);
        return plistData;
    }
    static Tricks Parse(XElement dict)
    {
        var values = GetValues(dict);
        return new Tricks
        {
            SubTitle = (string)values["Name"],
            SubTitleDescription = (string)values["Description"]
        };
    }
    static Dictionary<string, XElement> GetValues(XElement dict)
    {
        return dict.Elements("key")
                   .ToDictionary(k => (string)k, k => (XElement)k.NextNode);
    }
