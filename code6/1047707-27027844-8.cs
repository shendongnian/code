    public List<object> GeneratePropertyForEachConstructor(Type type, string propertyName)
    {
    	var propertyInfo = type.GetProperty(propertyName);
    	return GeneratePropertyForEachConstructor(type, propertyInfo);
    }
    
    public List<object> GeneratePropertyForEachConstructor(Type type, PropertyInfo propertyInfo)
    {
    	List<object> results = new List<object>();
    	if (propertyInfo.PropertyType.IsClass)
    	{
    		var propType = propertyInfo.PropertyType.UnderlyingSystemType;
    		var constructors = propType.GetConstructors();
    		foreach (ConstructorInfo constructorInfo in constructors)
    		{
    			var parameterInfo = constructorInfo.GetParameters();
    			var constructorParams = new List<object>();
    			foreach (ParameterInfo constructorParam in parameterInfo)
    			{
    				object value = constructorParam.HasDefaultValue
    								   ? constructorParam.DefaultValue
    								   : constructorParam.ParameterType.IsValueType
    										 ? Activator.CreateInstance(constructorParam.ParameterType)
    										 : null;
    				constructorParams.Add(value);
    			}
    			results.Add(constructorInfo.Invoke(constructorParams.ToArray()));
    		}
    	}
    	return results;
    } 
