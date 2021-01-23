    [TestMethod()]
    public void FunctionATest()
    {
        var now = DateTime.Now;
        var mockAnother = new Mock<IAnother>();
        var mockTimeProvider = new Mock<ITimeProvider>();
        mockTimeProvider.Setup(x => x.Now).Returns(now);
        var mainJob = new MainJob(mockAnother.Object, mockTimeProvider.Object);
        mainJob.FunctionA();
        mockAnother.Verify(x => x.DoAnotherJob(now), Times.Once);
    }
