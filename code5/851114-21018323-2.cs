    public void GetBFMPart()
    {
    	IsBusy = true;
    		
    	var task = Task.Factory.StartNew(delegate
    	{
    		// do your work here then set IsBusy = false
    		for (int i = 0; i < 5; i++)
    		{
    			System.Threading.Thread.Sleep(1000);
    		}
    		
    		IsBusy = false;
    	});
    }
