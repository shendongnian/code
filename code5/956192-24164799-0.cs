    Dictionary<string, bool> GetEnabledAndTestedServices(Dictionary<string, bool> input)
    {
    	var testedServices = new Dictionary<string, bool>();
    	foreach(var kvp in input)
    	{
    		if(!kvp.Value) //disabled
    			continue;
    			
    		var type = Type.GetType(kvp.Key);
    		
    		if(type == null)
    			throw new Exception("This service does not exist!");
    			
    		var instance = Activator.CreateInstance(type);
    		
    		// if the Test() method is part of an interface
    		// public interface ITestableService { bool Test() }
    		// and it's implemented by all services we can do this:
    		var service = instance as ITestableService;
    		if(service != null)
    		{
    			if(service.Test())
    				testedServices.Add(kvp.Key, true);
    		} 
    		else //Otherwise we call it via reflection, you could also do dynamic
    		{
    			var testMethod = type.GetMethod("Test");
    			if(testMethod == null)
    				throw new Exception("The service is not testable");
    			
    			var testResult = testMethod.Invoke(instance, null) as bool?;
    			if(testResult.HasValue && testResult.Value)
    				testedServices.Add(kvp.Key, true);
    		}
    	}
    	
    	return testedServices;
    }
