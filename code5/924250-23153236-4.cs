    var xmlDocument = XDocument.Load("path");
    var newXML = new XElement("RATES",
                xmlDocument.Descendants()
                    .Where(x => x.Name.ToString().StartsWith("Field"))
                    .Select(
                        x =>
                            new XElement("RATE",
                                new XElement("ID", (string) x.Parent.Parent.Attribute("Name")),
                                new XElement("Code", (string) x.Parent.Parent.Attribute("Code")),
                                new XElement("DelID", (string) x.Parent.Attribute("ID")),
                                new XElement(x.Name, (string) x))));
    newXML.Save("newFile.xml");
