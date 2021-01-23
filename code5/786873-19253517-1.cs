    XDocument xmlDoc = new XDocument();
    xmlDoc.Add(
        new XElement("root",
            new XElement("file",
                new XAttribute("name", "example"),
                new XAttribute("hashcode", "hashcode example")
            )
        )
    );
    xmlDoc.Save("temp.xml");
    Console.WriteLine(System.IO.File.ReadAllText("temp.xml"));
