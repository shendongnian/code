    [TestMethod]
    public void ExampleTest()
    {
      var mock = new Mock<IRepo> { DefaultValue = DefaultValue.Mock, };
      // no setups needed!
      ...
    }
