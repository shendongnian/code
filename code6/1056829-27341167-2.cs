    private static string GetTableName(Type type)
    {
        //.... codes
        if (TableNameMapper != null)
        {
            name = TableNameMapper(type);
        }
        else
        {
            var tableAttr = //.... lookup attribute
            if (tableAttr != null)
                name = tableAttr.Name;
            else
            {
                name = type.Name + "s";
                if (type.IsInterface() && name.StartsWith("I"))
                        name = name.Substring(1);
            }
        }
