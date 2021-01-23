    public static void AddColumns(ref DataTable dt, Type elementType, string columnPrefix)
    {
    	MemberInfo[] miArray = elementType.GetMembers(
    		BindingFlags.Public | BindingFlags.Instance);
    	foreach (MemberInfo mi in miArray)
    	{
    		if (mi.MemberType == MemberTypes.Property)
    		{
    			PropertyInfo pi = mi as PropertyInfo;
    			if (pi.PropertyType.IsPrimitive || pi.PropertyType == typeof(String))
    				dt.Columns.Add(columnPrefix + pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType);
    			else AddColumns(ref dt, pi.PropertyType, pi.Name + ".");
    		}
    		else if (mi.MemberType == MemberTypes.Field)
    		{
    			FieldInfo fi = mi as FieldInfo;
    			if (fi.FieldType.IsPrimitive || fi.FieldType == typeof(String))
    				dt.Columns.Add(columnPrefix + fi.Name, fi.FieldType);
    			else AddColumns(ref dt, fi.FieldType, fi.Name + ".");
    		}
    	}
    }
