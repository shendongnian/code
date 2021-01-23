    private CancellationTokenSource cts;
    
    private void btnTest_Click(object sender, RoutedEventArgs e)
    {
        if(cts == null)
    	{
    		cts = new CancellationTokenSource(new TimeSpan(0, 0, 60)); // cancel after 60 seconds
    	}
    	
    	await Task.Run( () => Work(), cts.Token);
    	
    	cts = null;
    }
    void Work(CancellationToken token)
    {
	   // do work
	  token.ThrowIfCancellationRequested();
      // do work
    }
    
