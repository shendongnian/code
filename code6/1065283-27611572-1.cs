    private static string GetPropertyName(PropertyInfo prop)
    {
        var displayAttribute = prop.GetCustomAttribute<DisplayAttribute>();
        if (displayAttribute != null)
        {
            // GetName() fetches from the resource file of the current Thread Culture
            return displayAttribute.GetName();
        }
        else
        {
            return prop.Name;
        }
    }
