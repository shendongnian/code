    var notNeededBarNames = new List<int>() { 1, 3 };
    var xDoc = XDocument.Load(filename);
    xDoc.Descendants("Bar")
        .Where(bar => notNeededBarNames.Contains( (int)bar.Attribute("name")) )
        .Remove();
        
    var newXml = xDoc.ToString();
