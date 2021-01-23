    XDocument doc = XDocument.Load("c:\\somexmlfile.xml");
    XElement xProp = doc.Root.Elements().Where(p => p.Attribute("Name").Value == "StartTime").FirstOrDefault();
    if (xProp != null)
    {
        XElement xValue = xProp.Element("Value");
        if (xValue != null && !string.IsNullOrEmpty(xValue.Value))
        {
           double startTimeValue = double.Parse(xValue.Value);
        }
    }
    
