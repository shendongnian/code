    public class PropertyClass
    {
    	public PropertyClass()
    	{
    		Value = "default";
    	}
    
    	public PropertyClass(string value)
    	{
    		Value = value;
    	}
    
    	public string Value { get; private set; }
    }
    
    public class WhateverClass
    {
    	public PropertyClass Property { get; set; }   
    }
...
    var propertyInfo = typeof (WhateverClass).GetProperty("Property");
    if (propertyInfo.PropertyType.IsClass)
    {
    	var propType = propertyInfo.PropertyType.UnderlyingSystemType;
    	var constructors = propType.GetConstructors();
    	var propertyClasses = new List<PropertyClass>();
    	foreach (ConstructorInfo constructorInfo in constructors)
    	{
    		var parameterInfo = constructorInfo.GetParameters();
    		var constructorParams = new List<object>();
    		foreach (ParameterInfo constructorParam in parameterInfo)
    		{
    			object value = constructorParam.HasDefaultValue ? constructorParam.DefaultValue : 
    				constructorParam.ParameterType.IsValueType ? Activator.CreateInstance(constructorParam.ParameterType) : null;
    			constructorParams.Add(value);
    		}
    		propertyClasses.Add((PropertyClass)constructorInfo.Invoke(constructorParams.ToArray()));
    	}
    	foreach (PropertyClass propertyClass in propertyClasses)
    	{
    		Console.WriteLine(propertyClass.Value);
    	}
    }
