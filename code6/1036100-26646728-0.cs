    public static Func<object, object> CreateGetter(Type runtimeType, string propertyName)
	{
		var propertyInfo = runtimeType.GetProperty(propertyName);
		var obj = Expression.Parameter(typeof(object), "obj");  // create a parameter (object obj)
		var objT = Expression.TypeAs(obj, runtimeType); // cast obj to runtimeType
		var property = Expression.Property(objT, propertyInfo); // property accessor
		var convert = Expression.TypeAs(property, typeof(object));
		return (Func<object, object>)Expression.Lambda(convert, obj).Compile();
	}
