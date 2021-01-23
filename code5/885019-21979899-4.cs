    public IList CreateList(Type type)
    {
        var genericList = typeof(List<>).MakeGenericType(type);
        return (IList)Activator.CreateInstance(genericList);
    }
