    // this is alternative for typeof(T).GetProperties()
    // that returns base class properties before inherited class properties
    protected PropertyInfo[] GetBasePropertiesFirst(Type type)
    {
        var orderList = new List<Type>();
        var iteratingType = type;
        do
        {
            orderList.Insert(0, iteratingType);
            iteratingType = iteratingType.BaseType;
        } while (iteratingType != null);
        var props = type.GetProperties()
            .OrderBy(x => orderList.IndexOf(x.DeclaringType))
            .ToArray();
        return props;
    }
