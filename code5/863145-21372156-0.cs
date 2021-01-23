    [TestMethod]
    public void ClientReceivesData()
    {
     var mockServer = new Mock<IServer>();//fails, makes you create the interface
     var client = new Client(mockServer.Object); // fails, makes you create client
    
     mockServer.Raise(s=>s.SendData+=null).Returns("test"); 
     // makes you create an event in the interface. Please check the syntax
    
     client.Listen(); 
     //makes you have some code on the client side to listen to server data.
     Assert.AreEqual("test", client.ReceivedData);// one of the many ways of asserting
    }
