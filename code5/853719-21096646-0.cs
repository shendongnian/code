	foreach (var property in properties)
	{
	    Expression.Property( 
             Expression.ConvertChecked( inputObject, property.DeclaringType ),
             property);
	}
