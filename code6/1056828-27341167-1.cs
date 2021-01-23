    private static string GetTableName(Type type)
    {
        string name;
        if (!TypeTableName.TryGetValue(type.TypeHandle, out name))
        {
            // This is your problem here
            name = type.Name + "s";
            if (type.IsInterface && name.StartsWith("I"))
                name = name.Substring(1);
          
            //NOTE: This as dynamic trick should be able to handle both our own Table-attribute as well as the one in EntityFramework 
            var tableattr = type.GetCustomAttributes(false).Where(attr => attr.GetType().Name == "TableAttribute").SingleOrDefault() as
                dynamic;
            if (tableattr != null)
                name = tableattr.Name;
            TypeTableName[type.TypeHandle] = name;
        }
        return name;
    }
