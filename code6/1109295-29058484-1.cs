    [TestMethod]
    public void TestMethod2()
    {
        var mock = new Moq.Mock<IFoo>();
        mock.Setup(m => m.GetCountry()).Returns(new List<string> { "America", "Philippines", "Japan" });
        // Pass mocked object to your constructor:
        ClassLibrary1.Class1 foo = new ClassLibrary1.Class1(mock.Object);
        foo.Process();
    }
