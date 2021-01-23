    public static T GetEntity<T>(DataRow row) where T : new()
    {
        var entity = new T();
        var properties = typeof(T).GetProperties();
    
        foreach (var property in properties)
        {
            //Get the description attribute
            var descriptionAttribute = (DescriptionAttribute)property.GetCustomAttributes(typeof(DescriptionAttribute), true).SingleOrDefault();
            if (descriptionAttribute == null)
                continue;
    
            property.SetValue(entity, row[descriptionAttribute.Description]);
        }
    
        return entity;
    }
