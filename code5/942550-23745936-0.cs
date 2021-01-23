    XDocument xdoc = XDocument.Parse(flickRes);
    var rootCategory = xdoc.Root.Element("domain").Element("makes");
    List<string> list = new List<string>();
    
    foreach (XElement book in rootCategory.Elements("make"))
    {
        string id = (string)book.Attribute("image");
        string name = (string)book;
        Debug.WriteLine(id);
        //list.Add(data);
    }
