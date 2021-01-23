    using (var context = new TestEntities())
    {
    	string procname = "GetPrograms";
    	// context has method GetPrograms(int? id)
    	
    	// Method1 - use the method on the context
    	// This won't work dynamically
    	IEnumerable<GetPrograms_Result> result1 = context.GetPrograms(4);
    	result1.Dump("Method1");
    	
    	// Method2 - use reflection to get and use the method on the context
    	// Building your parameters needs to be in the order they are on the method
    	// This gets you an IEnumerable, but not a strongly typed one
    
    	MethodInfo method = context.GetType().GetMethod(procname);
    	method.GetParameters();
    	List<object> parameters = new List<object>();
    	parameters.Add(4);
    	
    	IEnumerable result2 = (IEnumerable) method.Invoke(context,parameters.ToArray());
    	result2.Dump("Method2");
    
    	// Method3 - make a SqlQuery call on a common return type, passing a dynamic list
    	// of SqlParameters.  This return type can be but dows not need to be an Entity type
    
    	var argList = new List<SqlParameter>();
    	argList.Add(new SqlParameter("@id",4));
    	
    	object[] prm = argList.ToArray();
    	var csv = String.Join(",",argList.Select (l => l.ParameterName));
    
    	IEnumerable<GetPrograms_Result> result3 = context.Database.SqlQuery<GetPrograms_Result>("exec " + procname + " " + csv ,prm);
    	result3.Dump("Method3");
    }
