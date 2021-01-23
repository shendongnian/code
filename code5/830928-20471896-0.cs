    //don't this
    public class WorkerRole : RoleEntryPoint
    {
    	public override void Run()
    	{
    		// This is a sample worker implementation. Replace with your logic.
    		Trace.TraceInformation("WorkerRole1 entry point called", "Information");
    
    		while (true)
    		{
    			QueueClient Client = new QueueClient();
    			Thread.Sleep(10000);
    			Trace.TraceInformation("Working", "Information");
    		}
    	}
    }
    //use this
    public class WorkerRole : RoleEntryPoint
    {
    	public override void Run()
    	{
    		// This is a sample worker implementation. Replace with your logic.
    		Trace.TraceInformation("WorkerRole1 entry point called", "Information");
    
    		QueueClient client = new QueueClient();
    
    		while (true)
    		{
    			//client....
    			Thread.Sleep(10000);
    			Trace.TraceInformation("Working", "Information");
    		}
    	}
    }
