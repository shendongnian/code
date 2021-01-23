    const string someText = "qwert <tag>qwe</tag> qwerty";
    
    var element = new XElement("sometag");
    
    var settings = new XmlReaderSettings
    {
        ConformanceLevel = ConformanceLevel.Fragment
    };
    
    using (var sr = new StringReader(someText))
    using (var xr = XmlReader.Create(sr, settings))
    {
        xr.MoveToContent();
    
        while (!xr.EOF)
        {
            var node = XNode.ReadFrom(xr);   
            element.Add(node);
        }
    }
