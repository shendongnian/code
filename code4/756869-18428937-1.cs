    public class GreeterTests
    {
        [Test]
        public void SendGreetingToStackOverflow_CallsIMessageServiceSendSMSFiftyTimes()
        {
            // we mock this because it's tested elsewhere, we trust that it's working
            var mockMessageService = new Mock<IMessageService>();
            // this is the one we're testing
            var greeter = new Greeter(mockMessageService.Object);
            greeter.SendGreetingToStackOverflow();
            // was it called 50 times ? (maybe that's the amount of users)
            // you get the point
            mockMessageService.Verify(
                x => x.SendSMS("Hello World!"),
                Times.Exactly(50));
        }
    }
