    var xdoc = XDocument.Load(path_to_xml);
    string filenameTag = "file1.xml";
    var classes = xdoc.Descendants("file")
                        .Where(f => (string)f.Attribute("name") == filenameTag)
                        .Elements("model")
                        .Where(m => (string)m.Attribute("name") != null)
                        .Elements("class")
                        .Where(c => (string)c.Attribute("name") != null);
    foreach (var c in classes)
    {
        Console.WriteLine("Name: " + (string)c.Attribute("name"));
        foreach(var p in c.Elements())
           Console.WriteLine("Property: " + (string)p.Attributes().FirstOrDefault());
    }
