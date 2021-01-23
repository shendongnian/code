    private T MockObject<T>()
    {
        var mock = new Mock<IRepo>();
        mock.Setup(pa => pa.Reserve<T>()).Returns(new Mock<IA<T>>().Object);
    }
