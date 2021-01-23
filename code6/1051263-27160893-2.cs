    [Test]
    Public void DoSomethingTest()
    {
        //Arrange...
        // Mock MessageProperties so that we can manipulate the ip address in the message    
        MessagePropertiesHelper.SwitchCurrent(() => new MessageProperties());
        // Assert.
        ...
    }
