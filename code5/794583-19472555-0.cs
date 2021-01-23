    public static void UpdateTimer(long _)
    {
    	// do work to update the timer on the console
    }
    
    public static void Main()
    {
    	using (Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(UpdateTimer))
    	{
    		// code goes here that blocks while waiting for user input
    		// when the using block is left, the UpdateTimer function will stop being called.
    	}
    }
