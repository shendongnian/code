    private HttpRequestMessage _request;
    [SetUp]
    public void SetUp()
    {
      var builder = new ContainerBuilder();
      // Register stuff.
      var container = builder.Build();
      var resolver = new AutofacWebApiDependencyResolver(container);
      var config = new HttpConfiguration();
      config.DependencyResolver = resolver;
      config.EnsureInitialized();
      this._request = new HttpRequestMessage();
      this._request.SetConfiguration(config);
    }
    [TearDown]
    public void TearDown()
    {
      this._request.Dispose();
    }
    [Test]
    public void Test()
    {
      // When you need to resolve something, use the request message
      this._request.GetDependencyScope().GetService(typeof(TheThing));
    }
