    public static IList GetListByItemType(object instance, Type listItemType)
    {
        if(instance == null) throw new ArgumentNullException("instance");
        if(listItemType == null) throw new ArgumentNullException("listItemType");
        
        Type genericListType = typeof(List<>).MakeGenericType(listItemType);
        return instance.GetType().GetProperties().FirstOrDefault(property =>property.PropertyType == genericListType);
    }
