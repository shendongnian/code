    [TestMethod]
    public static void ClassInitialise(TestContext testContext)
    {       
       var configMock = new Mock<ICoolConfigurationProvider>();
       
       configMock.Setup(c => c.GetScheduledTasksSection())
                 .Returns(new NameValueCollection {{ "foo", "bar" }});
        
       var sut = new SUT(configMock.Object); // inject configuration provider
       // exercise sut
    }
