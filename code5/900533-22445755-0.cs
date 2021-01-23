    void Main()
    {
    	var tokenSource = new CancellationTokenSource();
    	var t=new Thread(_ => DoWork(tokenSource.Token));
    	for(;;) //loop forever
    	{
    		var input = Console.ReadLine();
    		if(input == "exit") 
    		{
    			tokenSource.Cancel();
    			break;
    		}
    	}
    }
    
    void DoWork(CancellationToken token)
    {
    	for(;;)
    	{
    		//do some work
    		if(token.IsCancellationRequested)
    		{
    			break;
    		}
    	}
    }
