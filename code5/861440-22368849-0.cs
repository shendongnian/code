    private static void SetPrivateProperty<T>(Object obj, string propertyName, object value)
    {
    	var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
    	if (propertyInfo == null) return;
    	propertyInfo.SetValue(obj, value, null);
    }
    
    private static object GetPrivateProperty<T>(Object obj, string propertyName)
    {
    	if (obj == null) return null;
    	var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
    	return propertyInfo == null ? null : propertyInfo.GetValue(obj, null);
    }
