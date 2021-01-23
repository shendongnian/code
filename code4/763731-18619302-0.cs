    public string GetServiceStatus(string machine, string service)
    {
        return Impersonate(
            () =>
                {
                    var service = new ServiceController(machine, service);
                    service.Refresh();
                    return service.Status;
                }, USER, DOMAIN, PASSWORD
            );    
    }
