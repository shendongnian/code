    [Test]
    public void SendGreetingToStackOverflow_CallsIMessageServiceSendSMSTwoTimes()
    {
        var mockMessageService = new Mock<IMessageService>();
        var mockSubscriberRepo = new Mock<ISubscriberRepository>();
        // we will mock the repo and pretend that it returns 2 subscibers
        mockSubscriberRepo
            .Setup(x => x.GetStackOverflowSubscribers())
            .Returns(new List<Subscriber>() {new Subscriber(), new Subscriber()});
        // this is the one we're testing, all dependencies are fake
        var greeter = new Greeter(mockMessageService.Object, mockSubscriberRepo.Object);
        greeter.SendGreetingToStackOverflow();
        // was it called 2 times (for each subscriber) ?
        mockMessageService.Verify(
            x => x.SendSMS("Hello World!"),
            Times.Exactly(2));
    }
