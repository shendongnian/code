    XDocument doc = XDocument.Load("c:\\somexmlfile.xml");
    XElement xProp = doc.Root.Elements.Where(p => p.Attribute('Name').Value == "StartTime").FirstOrDefault();
    if (xProp != null && !string.IsNullOrEmpty(xProp.Value))
    {
         double startTimeValue = double.Parse(xProp.Value);
    }
    
