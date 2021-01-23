    [TestMethod]
    public void it_should_do_something()
    {
        //Arrange
        var myClass = MyClassFactory
            .CreateEmpty()
            .WithService(serviceA)
            .WithOtherService(serviceB);
        //Act
        MyClass.DoSomething();
        //Assert
        //...
    }
