    public static bool IsServiceInstalled(string serviceName)
    {
      // get list of Windows services
      ServiceController[] services = ServiceController.GetServices();
    
      // try to find service name
      foreach (ServiceController service in services)
      {
        if (service.ServiceName == serviceName)
          return true;
      }
      return false;
    }
