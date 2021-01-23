    [Test]
    public void GetData()
    {
        var moqSvc = new Mock<IService>();
        // Provide some fake data to ensure that the SUT uses the return value correctly
        moqSvc.Setup(x => x.GetData(It.IsAny(int))).Returns(123.45);
        var сInfo = new ClientInfo(1, moqSvc.Object);
        // Ensure correct initial state
        Assert.AreEqual(0, cInfo.MoneySun)
        
        сInfo.UpdateMoney();
 
        // Ensure correct final state
        Assert.AreEqual(123.45, cInfo.MoneySun)
        // Ensure correct interaction with the service
        moqSvc.Verify(x => x.GetData(1), Times.Once);
        moqSvc.Verify(x => x.GetData(It.IsAny<int>(i => i != 1)), Times.Never);
    }
