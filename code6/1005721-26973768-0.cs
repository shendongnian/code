    [Test]
    public void Should_MyMethod()
    {           
        EventServiceLocator.Default = new MockNinjectControllerFactory(_mockRepository);
        var sut=new DemoController();
        var scopeService EventServiceLocator.Default.GetInstance<IScopeofService>();
        var mockScopeService = Mock.Get(scopeService);
        mockScopeService.Setup(p => p.GetPrograms()).Returns(/* TODO */); 
    }
