    Dictionary<int, int?> dic = new Dictionary<int, int?>
    {
        {1,null},
        {2,null},
        {3,2},
        {4,2},
        {5,4},
        {6,5},
        {7,2}
    };
    
    XElement root = new XElement("root");
    foreach (var kvp in dic)
    {
        XElement node = new XElement("item", new XAttribute("id", kvp.Key));
    
        int? parentId = kvp.Value;
        if (null == parentId)
            root.Add(node);
        else
        {
            // Get first item with id of parentId
            XElement parent = root.Descendants("item")
                .FirstOrDefault(i => (int)i.Attribute("id") == (int)parentId);
            if (null != parent) // which it shouldn't for our array
                parent.Add(node);
        }
    }
