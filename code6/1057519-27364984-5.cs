    var jArr = JArray.Parse(File.ReadAllText(filename));
    XElement root = new XElement("root");
    foreach(JObject jObj in jArr )
    {
        root.Add(new XElement("item", jObj.Properties()
                                          .Select(p => new XElement(p.Name, 
                                                                    p.Value.ToString()))
                                          .ToArray()));
    }
    var xml = root.ToString();
