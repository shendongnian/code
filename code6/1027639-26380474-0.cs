    using (TextReader reader = File.OpenText(xmlFilePath))
    {
        // Any reason for not using XDocument.Load(xmlFilePath)?
        XDocument xmlDocument = XDocument.Load(reader);
        var items = xmlDocument.Descendants("apple");
        foreach (var item in items)
        {
            Console.WriteLine(item.Attribute("id").Value); // Or whatever
        }
    }
