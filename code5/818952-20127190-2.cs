    var item= xdoc.Descendants("Item")
                  .FirstOrDefault(i => (int)i.Attribute("ID") == id);
    if (item != null)   
    {
        var settings = item.Elements()
                           .ToDictionary(e => e.Name.LocalName, e => (string)e);
    }
