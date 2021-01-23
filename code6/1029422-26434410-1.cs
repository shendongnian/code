	public static string GetColumnName<T>(string propertyName)
	{
		string result = null;
		
		if (string.IsNullOrWhiteSpace(propertyName))
		{
			throw new ArgumentNullException();
		}
		
		var tableType = typeof(T);
		var properties = tableType.GetProperties(BindingFlags.GetProperty 
                                                 | BindingFlags.Instance 
                                                 | BindingFlags.Public);
		
		var property = properties
          .Where(p => p.Name.Equals(propertyName, 
                                   StringComparison.CurrentCultureIgnoreCase))
          .FirstOrDefault();
		
		if (property == null)
		{
          throw new Exception("PropertyName not found."); // bad example
		}
		else
		{
          result = property.Name;  //if no column attribute exists;
			
          var attributes = property.GetCustomAttributes();
			
          var attribute = attributes
            .Where(a => a is ColumnAttribute)
            .FirstOrDefault() as ColumnAttribute;
			
          if (attribute != null)
          {
            result = attribute.Name;
          }
		}
		return result;
	}
