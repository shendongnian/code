    using System.ServiceProcess;    
    ServiceController sc = new ServiceController(SERVICENAME);    
    if (sc.Status == ServiceControllerStatus.Stopped)
    {
        // do anything
    }
