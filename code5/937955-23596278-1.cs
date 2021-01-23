    private bool AddNewRow(DataGridView grid)
    {
        var collection = grid.DataSource;
        if (collection == null)
        {
            grid.Rows.Add();
            return true;
        }
        var itemType = GetCollectionItemType(collection.GetType());
        if (itemType != null && itemType != typeof(object) && !itemType.IsAbstract && itemType.GetConstructor(Type.EmptyTypes) != null)
        {
            try
            {
                dynamic item = Activator.CreateInstance(itemType);
                ((dynamic)collection).Add(item);
                if (!(collection is System.ComponentModel.IBindingList))
                {
                    grid.DataSource = null;
                    grid.DataSource = collection;
                }
                return true;
            }
            catch { }
        }
        return false;
    }
    public static Type[] GetGenericArguments(this Type type, Type genericTypeDefinition)
    {
        if (!genericTypeDefinition.IsGenericTypeDefinition)
            return Type.EmptyTypes;
    
        if (genericTypeDefinition.IsInterface)
        {
            foreach (var item in type.GetInterfaces())
                if (item.IsGenericType && item.GetGenericTypeDefinition().Equals(genericTypeDefinition))
                    return item.GetGenericArguments();
        }
        else
        {
            for (Type it = type; it != null; it = it.BaseType)
                if (it.IsGenericType && it.GetGenericTypeDefinition().Equals(genericTypeDefinition))
                    return it.GetGenericArguments();
        }
    
        return new Type[0];
    }
    public static Type GetCollectionItemType(Type collectionType)
    {
        var args = GetGenericArguments(collectionType, typeof(IEnumerable<>));
        if (args.Length == 1)
            return args[0];
    
        return typeof(IEnumerable).IsAssignableFrom(collectionType)
            ? typeof(object)
            : null;
    }
