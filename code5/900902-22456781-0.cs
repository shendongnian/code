    XDocument xDoc;
    int lastId = 0;
    var path = Server.MapPath("data.xml");
    if (File.Exists(path))
    {
       xDoc = XDocument.Load(path);
       var existingCloths = xDoc.Root.Elements("cloths");
       if (existingCloths.Any())
       {
           lastId = existingCloths.Max(c => Int32.Parse(c.Attribute("Id").Value));
       }
    }
    else
    {
       xDoc = new XDocument(new XElement("products"));
    }
    var xCloths = XDoc.CreateElement("cloths");
    xDoc.SetAttribute("Id", (lastId + 1).ToString(CultureInfo.InvariantCulture);
    xDoc.Root.AppendChild(xCloths);
    //[...]
