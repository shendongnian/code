    // load file into string[]
    var input = File.ReadAllLines("TextFile1.txt");
    // in case you have more than one home in your file
    var homes =
        new XDocument(
            new XElement("root",
                 from line in input
                 let items = line.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries)
                 group new { line, items } by items[0] into g
                 select new XElement(g.Key,
                     from rooms in g.OrderBy(x => x.line.Length).Skip(1)
                     group rooms by rooms.items[1] into g2
                     select new XElement(g2.Key,
                         from name in g2.OrderBy(x => x.line.Length).Skip(1)
                         select new XElement(name.items[2], string.Format("This is a {0}", name.items[2]))))));
    // get the right home
    var home = new XDocument(homes.Root.Element("home"));
