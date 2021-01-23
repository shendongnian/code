    [TestMethod]
    public void NoIntegers()
    {
        Mock<IBar> mockBar = new Mock<IBar>(MockBehavior.Strict);
        
        mockBar.SetupGet(x => x.Integers)
               .Returns(new List<int>());
        Assert.IsFalse(new Foo(mockBar.Object).AreThereIntegers());
    }
    [TestMethod]
    public void HasIntegers()
    {
        Mock<IBar> mockBar = new Mock<IBar>(MockBehavior.Strict);
        
        mockBar.SetupGet(x => x.Integers)
               .Returns(new List<int>{ 3, 5, 6});
        Assert.IsTrue(new Foo(mockBar.Object).AreThereIntegers());
    }
