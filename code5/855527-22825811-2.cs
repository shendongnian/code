    // In the base class
    protected void Load(string queryName)
    {
        // Get the type of the domain context
        Type contextType = Context.GetType();
        // Get the method information using the method info class
        MethodInfo query = contextType.GetMethod(methodName);
        // Invoke the Load method, passing the query we got through reflection
        Load(query.Invoke(this, null));
    }
 
    // Then to call it
    dataService.Load("GetUsersQuery");
