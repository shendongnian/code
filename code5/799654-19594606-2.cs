    private ServiceHost _host;
    [SetUp]
    public void Setup()
    {
        _host = new ServiceHost(typeof(Service1), _baseAddress);
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
        _host.Description.Behaviors.Add(smb);
        _host.Open();
        // creating client as above
    }
    [TearDown]
    public void TearDown()
    {
        // closing client as above
        if (_host != null)
            _host.Close();
    }
