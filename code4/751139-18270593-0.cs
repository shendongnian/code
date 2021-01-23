    [Test]
    public void ShouldSendEmail()
    {
        IEmailService mockEmailService = Substitute.For<IEmailService>();
        MyEmailSendingThingy thingUnderTest = new MyEmailSendingThingy(mockEmailService);
    
        thingUnderTest.DoSomeWorkThatInvolvesSendingEmails();
    
        mockEmailService.Received().SnedEmail("foo@foo.foo", "bar@bar.bar, "Subject", "Some Text");
    }
