    private Mock<IRepo> MockObject<T>()
    {
        var mock = new Mock<IRepo>();
        return mock.Setup(pa => pa.Reserve<T>())
            .Returns(new Mock<IA<T>>().Object).Object;
    }
