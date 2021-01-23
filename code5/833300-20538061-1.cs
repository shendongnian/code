    foreach (XElement table in xdoc.Root.Elements("table"))
    {
        string tableName = (string) table.Attribute("name");
        StringBuilder fields = new StringBuilder();
        foreach (XElement field in table.Elements("field"))
        {
            string fieldName = (string) field.Attribute("name");
            string type = (string) field.Attribute("type");
            // Consider casting to int instead...
            string size = (string) field.Attribute("size");
            bool identity = (bool) field.Attribute("identity");
            bool primaryKey = (bool) field.Attribute("primarykey");
            string description = (string) field.Attribute("description");
            string reference = (string) field.Attribute("reference");
            // Append to fields here
        }
    }
