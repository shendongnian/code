    var myVariable = "Direct Access Site";
    XDocument doc = XDocument.Load(your file);
    var result = doc.Descendants("sitesEQ")
                   .Where(i => i.Element("nameEQ").Value == myVariable )
                   .Select(i => i.Attribute("sitePathEQ").Value);
    foreach (string item in result)
    {
        Console.WriteLine(item);
    }
