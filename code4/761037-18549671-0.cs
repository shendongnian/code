    var types = XDocument.Parse(TEXT())
                    .Descendants("type")
                    .Select(t => new SubType
                    {
                        AssemblyName = t.Attribute("assembly").Value,
                        ClassName = t.Attribute("class").Value,
                        Configuration = t.Element("type-configuration")
                                         .Elements()
                                         .ToDictionary(c=>c.Name.LocalName,c=>c.Value)
                    })
                    .ToList();
---
    public class SubType
    {
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        public Dictionary<string, string> Configuration { set; get; }
    }
