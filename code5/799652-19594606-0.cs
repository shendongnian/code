    private Uri _baseAddress = new Uri("http://localhost:8713/service1");
    private IService1 _client;
    [SetUp]
    public void Setup()
    {
        var binding = new BasicHttpBinding();
        var endpoint = new EndpointAddress(_baseAddress);
        var factory = new ChannelFactory<IService1>(binding, endpoint);
        _client = factory.CreateChannel();
    }
    [TearDown]
    public void TearDown()
    {
        if (_client != null)
            ((ICommunicationObject)_client).Close();
    }
    [Test]
    public void ShouldReturnSampleData()
    {
        Assert.That(_client.GetData(42), Is.EqualTo("You entered: 42"));
    }
