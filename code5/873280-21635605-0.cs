	if (!propertyInfo.PropertyType.IsEnum)
	{
		yield return new OracleParameter
		{
			ParameterName = columnAttribute.Name,
			Value = propertyInfo.GetValue(object, null)
		};
	}
	else
	{
	    var enumUnderlyingType = Enum.GetUnderlyingType(propertyInfo.PropertyType);
		var value = propertyInfo.GetValue(objeto, null);
		
		yield return new OracleParameter 
		{
			ParameterName = columnAttribute.Name,
			Value = Convert.ChangeType(value, enumUnderlyingType)
		};
	}
