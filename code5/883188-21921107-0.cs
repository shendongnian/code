    public static ParameterExpression Parameter(Type type, string name)
    {
    	bool isByRef = type.IsByRef;
    	if (isByRef)
    	{
    		type = type.GetElementType();
    	}
    	return ParameterExpression.Make(type, name, isByRef);
    }
    
    public static ParameterExpression Variable(Type type, string name)
    {
    	if (type.IsByRef)
    	{
    		throw Error.TypeMustNotBeByRef();
    	}
    	return ParameterExpression.Make(type, name, false);
    }
