    var xmlDocument = XDocument.Load("path");
    var rates = new List<XElement>();
    foreach (var type in xmlDocument.Descendants("Type"))
    {
        foreach (var del in type.Elements("Del"))
        {
              foreach (var field in del.Elements())
              {
                  XElement rate = new XElement("RATE",
                            new XElement("ID", (string) type.Attribute("Name")),
                            new XElement("Code", (string) type.Attribute("Code")),
                            new XElement("DelID", (string) del.Attribute("ID")),
                            new XElement(field.Name, (string) field));
                  rates.Add(rate);
              }
        }
    }
    XElement root = new XElement("RATES");
    root.Add(rates);
    root.Save("newFile.xml");
