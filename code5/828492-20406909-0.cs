    ServiceController svc = new ServiceController("serviceName");
    
    if  ((svc.Status.Equals(ServiceControllerStatus.Stopped)) ||
    	 (svc.Status.Equals(ServiceControllerStatus.StopPending)))
    {
    	try
    	{
    	   svc.Start();
    	}
    	catch(Exception ex)
    	{
    	   //log, abort, drink beer, etc
    	}
    }
