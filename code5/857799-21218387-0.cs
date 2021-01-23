	Type type = address.GetType();
	
	for (int i=0; i < reader.FieldCount; i++)
	{
		var property = type.GetProperty(reader.GetName(i));
		
		var setMethod = property.GetSetMethod();
		
		setMethod.Invoke(address, new object[]{reader[i]});
	}
