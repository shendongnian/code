    public  bool IsServiceInstalled(String aServiceName)
    {
       ServiceController sc = ServiceController.GetServices()
           .FirstOrDefault(s => s.ServiceName == aServiceName);
       return (sc != null) ;
    }
