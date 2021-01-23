    [TestMethod]
    public void it_should_do_something()
    {
        //Arrange
        var myClass = MyClassFactory.Create(
            MyServiceFactory.CreateStubWithTemperature(45),
            MyOtherServiceFactory.CreateStubWithContents("test string"));
        //Act
        MyClass.DoSomething();
        //Assert
        //...
    }
