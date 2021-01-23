    protected override void OnStart(string[] args)
    {
        if (_serviceHost != null)
        {
            _serviceHost.Close();
        }
    
        _counterObject = new CounterClass();
        _counterObject.StartCounting();
    
        _wcfService = new CounterWCFService(_counterObject);
    
        _serviceHost = new ServiceHost(_wcfService);
        _serviceHost.Open();
    }
