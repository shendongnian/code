    public void Add(object obj, string propertyName, IEnumerable enumerable)
    {
        Action<object> add;
        
        PropertyInfo prop = obj.GetType().GetProperty(propertyName);
        var property = prop.GetValue(obj, null);
        
        var collection = property as IList;
        
        // Check for IList
        if(collection != null)
        {
            add = item => collection.Add(item);
        }
        // Try to get an Add method as fallback
        else
        {
            var objType = obj.GetType();
            var addMethod = objType.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);
            
            // Property doesn't support Adding
            if(addMethod == null) throw new InvalidOperationException("Method Add does not exist on class " + objType.Name);
            
            add = item => addMethod.Invoke(obj, new object[] { item });
        }
        
        foreach (var item in enumerable)
        {
            add(item);
        }
    }
