    ServiceController sc = new ServiceController();
    sc.ServiceName = "myservice";
    
    if (sc.Status == ServiceControllerStatus.Running || 
    	sc.Status == ServiceControllerStatus.StartPending)
    {
    	Console.WriteLine("Service is already running");
    }
    else
    {
    	try
    	{
    		Console.Write("Start pending... ");
    		sc.Start();
    		sc.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
    
    		if (sc.Status == ServiceControllerStatus.Running)
    		{
    			Console.WriteLine("Service started successfully.");
    		}
    		else
    		{
    			Console.WriteLine("Service not started.");
    			Console.WriteLine("  Current State: {0}", sc.Status.ToString("f"));
    		}
    	}
    	catch (InvalidOperationException)
    	{
    		Console.WriteLine("Could not start the service.");
    	}
    }
