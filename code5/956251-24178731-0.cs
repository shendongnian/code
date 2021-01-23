    public void MoqCanBeSetupWithDelegator()
    {
        var mock = new Mock<IInterface>();
        Func<string, int> valueFunction = i => i == "true" ? 1 : default(int);
        mock.Setup(x => x.Method(It.IsAny<string>())).Returns(valueFunction);
        Assert.Equal(1, mock.Object.Method("true"));
        Assert.Equal(0, mock.Object.Method("anonymous"));
    }
    public interface IInterface
    {
        int Method(string arg);
    }
