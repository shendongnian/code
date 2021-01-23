	private static Queue<PropertyInfo> GetProperty(object obj, string path)
	{
		Queue<PropertyInfo> values = new Queue<PropertyInfo>();
		Type object_type = obj.GetType();
		string[] properties = path.Split('.');
		PropertyInfo propertyInfo = null;
		foreach (string property in properties)
		{
			if (propertyInfo != null)
			{
				Type propertyType = propertyInfo.PropertyType;
				propertyInfo = propertyType.GetProperty(property);
				values.Enqueue(propertyInfo);
			}
			else
			{
				propertyInfo = object_type.GetProperty(property);
				values.Enqueue(propertyInfo);
			}
		}
		return values;
	}
