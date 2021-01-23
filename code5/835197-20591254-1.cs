    [Test]
    public void MoqTest()
    {
        var mock = new Moq.Mock<AbstractBaseClass>();            
        // set the behavior of mocked methods
        mock.Setup(abs => abs.Foo()).Returns(5);
        // getting an instance of the class
        var abstractBaseClass = mock.Object;
        // Asseting it actually works :)
        Assert.AreEqual(5, abstractBaseClass.Foo());
    }
