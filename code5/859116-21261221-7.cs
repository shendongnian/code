    [TestMethod]
    public void ShouldDoSomething()
    {       
       var configMock = new Mock<IConfigurationProvider>();
       
       configMock.Setup(c => c.GetScheduledTasksSettings())
                 .Returns(new NameValueCollection {{ "foo", "bar" }});
        
       var sut = new SUT(configMock.Object); // inject configuration provider
       sut.Exercise();
       // Assertions
    }
