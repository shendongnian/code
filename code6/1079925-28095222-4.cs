    public static IList GetListByItemType(object instance, string listItemTypeName)
    {
        if(instance == null) throw new ArgumentNullException("instance");
        if(listItemTypeName== null) throw new ArgumentNullException("listItemTypeName");
        
     
        PropertyInfo property = instance.GetType().GetProperties().FirstOrDefault(property =>property.IsGenericType && property.PropertyType.GetGenericArguments()[0].Name== listItemTypeName);
        if(property != null)
            return (IList)property.GetValue(instance);
        return null;
    }
