    [TestMethod]
    public void TestToTestInterface()
    {
        //Arrange
    
        var instance = A.Fake<IClassWithMethods>();
    
        //Make calling Test2 return 5 and not 10.
        A.CallTo(() => instance.Test2()).Returns(5);
    
        //Call the method 
        var sum = instance.Test1();
    
        //Assert if the business logic in the method works.
        Assert.AreEqual(0, sum); // because Test1 wasn't faked
    }
