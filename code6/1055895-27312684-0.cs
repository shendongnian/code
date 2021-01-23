    List<object> collection = this.ResolveCollection(targetType);
    
    var itemType = targetType.GetGenericArguments()[0];
    var listType =  typeof(List<>).MakeGenericType(itemType);
    
    var listInstance = Activator.CreateInstance(listType, new object[0]) as IList;
    foreach (var instance in collection) 
    {
        listInstance.Add(instance);
    }
    
    return (T)listInstance;
