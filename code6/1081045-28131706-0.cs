	PropertyInfo propertyInfo;
	foreach (YourClass C in list)
	{
		propertyInfo = C.GetType().GetProperty(propertyName);
		propertyInfo.SetValue(C, Convert.ChangeType(appendedValue, propertyInfo.PropertyType), null);
	}
