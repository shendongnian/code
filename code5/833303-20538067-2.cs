    XDocument xdoc = XDocument.Load("d:\\tables.xml");
    foreach (XElement table in xdoc.Root.Elements("table"))
    {
        tableName = (string)table.Attribute("name");
        foreach (XElement field in table.Elements("field"))
        {
            fieldName = (string)field.Attribute("name");
            type = (string)field.Attribute("type");
            size = (int)field.Attribute("size"); // that will be an integer
            identity = (bool)field.Attribute("identity"); // boolean
            primarykey = (bool)field.Attribute("primarykey"); // boolean
            description = (string)field.Attribute("description");
            reference = (string)field.Attribute("reference");
            // ...
        }
    }
