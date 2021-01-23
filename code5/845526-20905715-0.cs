    public static RouteValueDictionary ToRouteValueDictionary(this object obj)
    {
        var Result = new RouteValueDictionary(obj);
        // Find any ignored properties
        var BindAttribute = (BindAttribute)obj.GetType().GetCustomAttributes(typeof(BindAttribute), true).SingleOrDefault();
        var ExcludedProperties = new List<string>();
        if (BindAttribute != null)
        {
            ExcludedProperties.AddRange(BindAttribute.Exclude.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        }
        // Remove any ignored properties from the dictionary
        foreach (var ExcludedProperty in ExcludedProperties)
        {
            Result.Remove(ExcludedProperty);
        }
            
        // Loop through each property, recursively adding sub-properties that end with "Model" to the dictionary
        foreach (var Property in obj.GetType().GetProperties())
        {
            if (ExcludedProperties.Contains(Property.Name))
            {
                continue;
            }
            if (Property.PropertyType.Name.EndsWith("Model"))
            {
                Result.Remove(Property.Name);
                var PropertyValue = Property.GetValue(obj, null);
                if (PropertyValue != null)
                {
                    var PropertyDictionary = PropertyValue.ToRouteValueDictionary();
                    foreach (var Key in PropertyDictionary.Keys)
                    {
                        Result.Add(string.Format("{0}.{1}", Property.Name, Key), PropertyDictionary[Key]);
                    }
                }
            }
        }
        return Result;
    }
