    public static object GetValueByColumnName(string colName, object record)
    {
    	var isComplexProperty = colName.Split('.').Length > 1;
    	if (!isComplexProperty)
    	{
    		return GetSimplePropertyValue(colName, record);
    	}
    	else
    	{
    		var propertyName = colName.Split('.')[0];
    		var propertyValue = GetSimplePropertyValue(propertyName, record);
    		if (propertyValue != null)
    			return GetValueByColumnName(colName.Replace(propertyName + ".", ""), propertyValue);
    	}
    	return null;
    }
    
    public static object GetSimplePropertyValue(string propName, object record)
    {
    	Type elementType = record.GetType();
    	MemberInfo mi = elementType.GetMember(propName)[0];
    	if (mi.MemberType == MemberTypes.Property)
    	{
    		PropertyInfo pi = mi as PropertyInfo;
    		return pi.GetValue(record, null);
    	}
    	else if (mi.MemberType == MemberTypes.Field)
    	{
    		FieldInfo fi = mi as FieldInfo;
    		return fi.GetValue(record);
    	}
    	return null;
    }
