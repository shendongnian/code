    public string TopFunction()
    {
    	var task = Combine(InBetweenFunction2(), InVetweenFunction2());
    	
    	// Blocking call
    	// Really you shouldn't be doing this unless you really really
    	// have to.
    	task.Wait();
    	
    	return task.Result;
    }
     
