    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load(filename);
    var colors = doc.DocumentNode.Descendants("font")
                 .ToDictionary(e => e.InnerText, e => e.Attributes["color"].Value);
    foreach(var color in colors)
    {
        Console.WriteLine("{0}:{1}", color.Key, color.Value);
    }
