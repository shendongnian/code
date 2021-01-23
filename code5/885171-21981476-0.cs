    public Task<byte[]> GetSomeDataAsync()
    {
	    var tcs = new TaskCompletionSource();
	
        IAsyncResult result = myServiceClient.BeginDoSomething(someInputValue, x => 
	    {
		    try
		    {
		      	var data = _pdfCreatieService.EndCreateForPreview(result);
		        tcs.SetResult(data);
		    }
   		    catch(Exception ex)
  		    {
		  	    tcs.SetException(ex);
		    }
	    }, null);
        return tcs.Task;
    }
