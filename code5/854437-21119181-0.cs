	public static Action<TObj, TProp> GenerateSetter<TObj, TProp>(string propertyName)
	{
		var type = typeof(TObj);
		var property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
		MethodInfo setterMethodInfo = property.SetMethod;
		ParameterExpression paramo = Expression.Parameter(typeof(TObj), "param");
		ParameterExpression parami = Expression.Parameter(typeof(TProp), "newvalue");
		MethodCallExpression methodCallSetterOfProperty = Expression.Call(paramo, setterMethodInfo, parami);
		Expression setPropertyValueExp = Expression.Lambda(methodCallSetterOfProperty, paramo, parami);
		var setPropertyValueLambda = (Expression<Action<TObj, TProp>>)setPropertyValueExp;
		var setterFunc = setPropertyValueLambda.Compile();
		return setterFunc;
	}
