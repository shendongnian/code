    protected override void OnStart(string[] args)
    {
        if (serviceHost != null)
        {
            serviceHost.Close();
        }
        serviceHost = new ServiceHost(typeof(WSpExporter)); //GOOD NOW
        serviceHost.Open();
    }
