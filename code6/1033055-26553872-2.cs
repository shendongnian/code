	public static List<string> GetPropertyNames<T>()
	{
		string result = null;
		
		var tableType = typeof(T);
		var result = tableType.GetProperties(BindingFlags.GetProperty 
                                             | BindingFlags.Instance 
                                             | BindingFlags.Public)
          .Select(p => p.Name)
          .ToList();
		
		return result;
	}
    public static object GetValue(object classInstance, string propertyName)
    {
      var tableType = classInstance.GetType();
      var prop = tableType.GetProperty(propertyName);
      var result = prop.GetValue(classInstance);
      return result;
    }
