    System.Threading.Timer timer;
    void Main()
    {
    	RunActionAfter(() => DoTheWork(), 2000);
    }
    void RunActionAfter(Action action, int period)
    {
        //Timeout.Infinite means the timer runs only once.
    	timer = new Timer(_ => action(), null, 2000, Timeout.Infinite); 
    }
    void DoTheWork()
    {
    	Console.WriteLine("!!!");
    	
    	//then maybe
    	RunActionAfter(() => DoTheWork(),2000);
    }
