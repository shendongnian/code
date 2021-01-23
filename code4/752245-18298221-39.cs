    [TestMethod]
    public void it_should_do_something()
    {
        //Arrange
        var myClass = MyClassFactory.Create(serviceA, serviceB);
        //Act
        myClass.DoSomething();
        //Assert
        //...
    }
