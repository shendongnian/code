    [TestMethod]
    public void it_should_do_something()
    {
        //Arrange
        var myClass = MyClassFactory.Create(
            MyServiceFactory.CreateMockWithTemperature(45),
            MyOtherServiceFactory.CreateMockWithContents("test string"));
        //Act
        MyClass.DoSomething();
        //Assert
        //...
    }
