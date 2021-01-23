    EndpointAddress address = new EndpointAddress("http://localhost:8080/service1");
    ServiceHost host;        
    IService1 service;
    [TestFixtureSetUp]
    public void FixtureSetUp()
    {            
        var binding = new BasicHttpBinding();
        host = new ServiceHost(typeof(Service1), address.Uri);
        host.AddServiceEndpoint(typeof(IService1), binding, address.Uri);
        host.Open();
    }
    [TestFixtureTearDown]
    public void FixtureTearDown()
    {
        if (host == null)
            return;
        if (host.State == CommunicationState.Opened)
            host.Close();
        else if (host.State == CommunicationState.Faulted)
            host.Abort();
    }
