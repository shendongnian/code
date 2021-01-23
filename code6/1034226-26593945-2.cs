    var xml = new XElement("LOC", new XAttribute("ID", "*"));
    
    for (var i = 1; i < 10; i++)
    {
        xml.Add(CreateRow(i, "?", "?", 1, i));
    }
    
    Console.WriteLine(new XElement("ROOT", xml));
