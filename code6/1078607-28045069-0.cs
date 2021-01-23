    private static Type[] CollectTypesFromCollection(List<Class> collection)
    {
        List<Type> types = new List<Type>();
        foreach (Class item in collection)
            foreach (Property property in item.Property)
                if (!types.Contains(property.Value.GetType()))
                    types.Add(property.Value.GetType());
        return types.ToArray();
    }
