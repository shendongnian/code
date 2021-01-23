    int[] notNeededBarNames = new []{1,3};
    var xDoc = XDocument.Load(filename);
    xDoc.Descendants("Bar")
        .Where(bar => notNeededBarNames.Any(b => b == (int)bar.Attribute("name")))
        .Remove();
    var newXml = xDoc.ToString();
