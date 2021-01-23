	List<Argument> arguments = new List<Argument>
	{
		new Argument(){PropertyName = "AString", PropertyValue = "this is a string"},
		new Argument(){PropertyName = "AnInt", PropertyValue = 1729},
		new Argument(){PropertyName = "ADirInfo", PropertyValue = new DirectoryInfo(@"c:\logs")}
	};
	
	Blah b = new Blah();
	Type blahType = b.GetType();
	foreach(Argument arg in arguments)
	{
		PropertyInfo prop = blahType.GetProperty(arg.PropertyName);
		// If prop == null then GetProperty() couldn't find a property by that name.  Either it doesn't exist, it's not public, or it's defined on a parent class
		if(prop != null) 
		{
			prop.SetValue(b, arg.PropertyValue);
		}
	}
