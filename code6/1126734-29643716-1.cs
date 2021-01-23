    var element = new XElement("parent");
    
    var settings = new XmlReaderSettings
    {
        ConformanceLevel = ConformanceLevel.Fragment
    };
    
    var text = GetXmlString();
    
    using (var sr = new StringReader(text))
    using (var xr = XmlReader.Create(sr, settings))
    {
        xr.MoveToContent();
    
        while (!xr.EOF)
        {
            var node = XNode.ReadFrom(xr);   
            element.Add(node);
        }
    }
