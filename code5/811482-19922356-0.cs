    using System.ServiceProcess;
    
    ServiceController sc = new ServiceController(SERVICENAME);
    
    switch (sc.Status)
    {
        case ServiceControllerStatus.Running:
            return "Running";
        case ServiceControllerStatus.Stopped:
            return "Stopped";
        case ServiceControllerStatus.Paused:
            return "Paused";
        default:
            return "Status Changing";
    }
