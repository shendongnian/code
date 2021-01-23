    public List<SomeObject> Filter(
        List<SomeObject> collection, 
        string property, 
        string filterValue)
    {
        var filteredCollection = new List<SomeObject>();
        foreach (var item in collection)
        {
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
