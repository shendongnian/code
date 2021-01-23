    Type type = p.PropertyType;
    if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) &&
       typeof(EntityBase).IsAssignableFrom(type.GetGenericArguments()[0]))
    {
        // iterate list
    }
