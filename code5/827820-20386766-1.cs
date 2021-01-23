    public List<T> Filter<T>(
        List<T> collection, 
        string property, 
        string filterValue)
    {
        var filteredCollection = new List<T>();
        foreach (var item in collection)
        {
             // To check multiple properties use,
             // item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
          
             var propertyInfo = 
                 item.GetType()
                     .GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
             if (propertyInfo == null)
                 throw new NotSupportedException("Property given does not exists");             
             var propertyValue = propertyInfo.GetValue(item, null);
             if (propertyValue == filterValue)
                 filteredCollection.Add(item);       
        }
        
        return filteredCollection;
    }
