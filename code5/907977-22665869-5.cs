    private string GetDefaultValueForProperty([CallerMemberName] string name = "")
    {
        string defaultValue = null;
        var myPropertyInfo = this.GetType().GetProperty(name);
        var myAttributeInfo = myPropertyInfo.GetCustomAttribute<DefaultValueAttribute>();
        if (myAttributeInfo != null)
        {
            defaultValue = (string)myAttributeInfo.Value;
        }
    
        return defaultValue;
    }
