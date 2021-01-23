    public static void UseAttribute<T>(T sender)
    {
    	var hasAttribute = typeof(T).GetProperties().Any(prop => Attribute.IsDefined(prop, typeof(MyAttribute)));
    	if (!hasAttribute)
    		throw new Exception("Does not contain attribute");
    }
