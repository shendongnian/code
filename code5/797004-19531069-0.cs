    //replace object parameter with some base class if possible
    public static List<string> GetColumnValues(object item)
    {
        return item.GetType().GetProperties()
            .Where(prop => prop.Name.StartsWith("Col") 
                && prop.PropertyType == typeof(string))
            .Select(prop => prop.GetValue(item) as string)
            .ToList();
    }
