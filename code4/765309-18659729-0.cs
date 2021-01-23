    var doc = XDocument.Load("Input.txt");
    Func<XElement, IEnumerable<Item>> query = e => e.Elements("item")
                           .Select(x => new Item
                           {
                               Id = (string)x.Attribute("id"),
                               ModuleId = (string)x.Attribute("moduleid"),
                               View = (bool)x.Attribute("view"),
                               Add = (bool)x.Attribute("add"),
                               Edit = (bool)x.Attribute("edit"),
                               Delete = (bool)x.Attribute("del")
                           });
    var addItems = query(doc.Root.Element("add")).ToList();
    var updateItems = query(doc.Root.Element("update")).ToList();
