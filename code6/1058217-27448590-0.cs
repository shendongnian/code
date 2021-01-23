    protected T CloneE<T>(T entity, int depth) where T : new()
    {
        return (T)CloneInternal(entity, depth);
    }
    private object CloneInternal(object entity, int depth)
    {
        var cloned = Activator.CreateInstance(entity.GetType());
        foreach (var property in cloned.GetType().GetProperties())
        {
            if (property.PropertyType.Namespace == "System" && property.CanWrite)
            {
                property.SetValue(cloned, property.GetValue(entity));
            }
            else if (depth > 0 && property.CanWrite)
            {
                if (property.PropertyType.Namespace == "System.Collections.Generic")
                {
                    var type = property.PropertyType.GetGenericArguments()[0];
                    Type genericListType = typeof(List<>).MakeGenericType(type);
                    var collection = (IList)Activator.CreateInstance(genericListType);
                    var value = property.GetValue(entity);
                    foreach (var element in value as IEnumerable)
                    {
                        collection.Add(CloneInternal(element, depth - 1));
                    }
                    property.SetValue(cloned, collection);
                }
            }
        }
        return cloned;
    }
