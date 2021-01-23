    interface IFoo
    {
        int Bar(string baz);
    }
    
    var mock = new Mock<IFoo>();
    mock.Setup(x => x.Bar(It.IsAny<string>()))
        .Returns((string baz) => 42 /* Here baz contains the value your code provided */);
