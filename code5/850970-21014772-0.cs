    [TestMethod]
    public void TestConstructorSubscribesToMachineMessages()
    {
        var mockMachineDataService = new Mock<IMachineDataService<AlarmDto>>();
        var mockAggregator = new Mock<IEventAggregator>();
        var mockEvent = new Mock<MachineMessageReceivedEvent>();
        mockAggregator.Setup(x => x.GetEvent<MachineMessageReceivedEvent>()).Returns(mockEvent.Object);
        mockEvent.Setup(x => x.Subscribe(It.IsAny<Action<MachineMessage>>(), It.IsAny<ThreadOption>(), It.IsAny<bool>(), It.IsAny<Predicate<MachineMessage>>()));
        var alarmService = new AlarmService(mockAggregator.Object, mockMachineDataService.Object);
        Assert.IsNotNull(alarmService);
        
        mockAggregator.VerifyAll();
        mockEvent.VerifyAll();
    }
