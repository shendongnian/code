    XDocument root = XDocument.Parse(File.ReadAllText("xml.xml"));
    if (root != null)
    {
        IEnumerable<XElement> production = root.Root
            .Descendants("Production")
            .Where(x => x.Elements("employee")
                .Where(e => e.Attribute("empName").Value.Equals("John"))
                .Any()
            );
        if (production.Any())
        {
            Console.WriteLine("John found...");
        }
        else
        {
            Console.WriteLine("No John found");
        }
    }
