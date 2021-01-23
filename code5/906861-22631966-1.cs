        XDocument doc = XDocument.Load(@"D:\test.xml");
        var data = from item in doc.Descendants("save")
                   select new
                   {
                       cookies = item.Element("cookies").Value,
                       clickers = item.Element("clickers").Value,
                       workers = item.Element("workers").Value,
                       factories = item.Element("factories").Value,
                       slavecountries = item.Element("slavecountries").Value,
                       worlds = item.Element("worlds").Value,
                       planets = item.Element("planets").Value,
                       universes = item.Element("universes").Value,
                       realities = item.Element("realities").Value
                   };
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }
