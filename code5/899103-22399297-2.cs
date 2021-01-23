    public Task Func1Async(object param1, object param2)
    {
	   var tcs = new TaskCompletionSource<object>();
	
	    myLib.CompletionEvent += (r => 
	    {
	    	Debug.Write(String.Format("Success: {0}", ar.success));
		
	    	// if failure, get exception from r, which is of type ActionResult and 
	    	// set the exception on the TaskCompletionSource via tcs.SetException(e)
		
	    	// if success set the result
	    	tcs.SetResult(null);
    	});
	
    	// call the asynchronous function, which returns immediately
        myLib.Func1(param1, param2);
	
        //return the task associated with the TaskCompletionSource
	    return tcs.Task;
    }
