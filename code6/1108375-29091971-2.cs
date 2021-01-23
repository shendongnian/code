    // somewhere in the main program
    Queue<DataTable> MainQueue = new Queue<DataTable>();
    // or in .NET 4
    ConcurrentQueue<DataTable> MainConcurrentQueue = new ConcurrentQueue<DataTable>();
...
    
    void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	// read data from PLC
    	// parse, process the data
    	// create a **new** instance of the DataTable object
    	DataTable dt = new DataTable();
    	// and fill it with your data
    
    	// append the new DataTable object to the queue
    	mut.WaitOne();
    	try
    	{
    		MainQueue.Enqueue(dt);
    	}
    	catch { }
    	finally
    	{
    		mut.ReleaseMutex();
    	}
    
    	// or in .NET4 simply
    	MainConcurrentQueue.Enqueue(dt);
    }
