    void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	DataTable dt = null;
    
    	mut.WaitOne();
    	try
    	{
    		dt = MainQueue.Dequeue();
    	}
    	catch { }
    	finally
    	{
    		mut.ReleaseMutex();
    	}
    
    	// or in .NET4 simply
    	dt = MainConcurrentQueue.Dequeue();
    	// Send DataTable to the database
        // TODO: add checks for empty queue
        // TODO: add checks for long queue 
        // and send all or some of the accumulated elements to the DB
    }
