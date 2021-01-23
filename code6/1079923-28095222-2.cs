    public static IList GetListByItemType(object instance, Type listItemType)
    {
        if(instance == null) throw new ArgumentNullException("instance");
        if(listItemType == null) throw new ArgumentNullException("listItemType");
        
        Type genericListType = typeof(List<>).MakeGenericType(listItemType);
        PropertyInfo property = instance.GetType().GetProperties().FirstOrDefault(property =>property.PropertyType == genericListType);
        if(property != null)
          return (IList)property.GetValue(instance);
        return null;
    }
