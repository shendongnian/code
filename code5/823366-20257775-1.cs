    [TestCase]
    public void PostSendsCommandOnBus()
    {
        // ARRANGE
        var mockCommandBus = new MockCommandBus();
       
        ICommand expectedCommand = <whatever you expect>;
        MetaData expectedMetaData = <whatever you expect>;
    
        // Code to construct your CommandModule with mockCommandBus.
    
        // ACT
        // Code to invoke the method being tested.
    
        // ASSERT
        Assert.AreEqual(expectedCommand, mockCommandBus.PassedCommand);
        Assert.AreEqual(expectedMetaData , mockCommandBus.PassedMetaData );
    
    }
