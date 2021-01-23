    container.For<Logger>().AlwaysUnique().Use(ctx =>
    {
    	var pi = typeof (BuildFrame).GetProperty("Parent", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    	var frame = ctx.BuildStack.Parent;
    
    	while (frame != null)
    	{
    		var currentType = frame.ConcreteType;
    
    		if (currentType == typeof(ServiceA))
    			return new LoggerA();
    		if (currentType == typeof(ServiceB))
    			return new LoggerB();
    
    		frame = (BuildFrame)pi.GetValue(frame, null);
    	}
    	
    	return new LoggerDefault();
    }
