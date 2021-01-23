    [TestMethod]
    public void it_should_do_something()
    {
        //Arrange
        var serviceA = MyServiceFactory.CreateMockWithTemperature(45);
        var serviceB = MyOtherServiceFactory.CreateMockWithContents("test string");
        var myClass = MyClassFactory
            .CreateEmpty()
            .WithService(serviceA)
            .WithOtherService(serviceB);
        //Act
        MyClass.DoSomething();
        //Assert
        //...
    }
