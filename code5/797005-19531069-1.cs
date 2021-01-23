    //replace object parameter with some base class if possible
    public static void GetColumnValues(object item, List<string> values)
    {
        foreach(var pair in item.GetType().GetProperties()
            .Where(prop => prop.Name.StartsWith("Col") 
                && prop.PropertyType == typeof(string))
            .Zip(values, (prop, value) => new{prop,value})
        {
            pair.prop.SetValue(item, pair.value);
        }
    }
