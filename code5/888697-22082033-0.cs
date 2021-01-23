    void Search(IQueryable<MyClass> results, string keywords, string propertyName)
    {
        PropertyInfo elePropInfo = ele.GetType().GetProperty(propertyName);
        string elePropValue = (string)elePropInfo.GetValue(ele, null); // the second argument should be null for non-indexed properties
        switch(operator)
        { 
            case "Contains":
                results = results.Where(ele => elePropValue.Contains(keywords));
                break;
            case "StartsWith:
                results = results.Where(ele => elePropValue.StartsWith(keywords));
                break;
            // etc
        }
    }
