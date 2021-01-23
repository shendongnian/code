    XDocument xDoc = XDocument.Load(filepath);
    var myList = xDoc.Descendants("item").Select(item => new Item {
                                          Id = (string)item.Attribute("name"),
                                          Property = (string)item.Element("property")
                                                                  }).ToList();
