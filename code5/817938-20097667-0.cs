    // .NET DataBinder class
    public static string GetPropertyValue(object container, string propName,
        string format)
    {
    	object propertyValue = DataBinder.GetPropertyValue(container, propName);
    	if (propertyValue == null || propertyValue == DBNull.Value)
    	{
    		return string.Empty;
    	}
    	if (string.IsNullOrEmpty(format))
    	{
    		return propertyValue.ToString();
    	}
    	return string.Format(format, propertyValue);
    }
