    [TestMethod]
    public void Is_OnConnected_Successive()
    {
        const string connectionId = "1";
        dynamic groupName = new ExpandoObject();
    
        var IsSendMessageCalled = false;
    
        groupName.sendMessage = new Action<object>((message) =>
        {
            IsSendMessageCalled = true;
            Debug.WriteLine("sendMessage was called, message:  {0}", message);
        });
    
        var request = new Mock<IRequest>();
        request.Setup(s => s.User.Identity.Name).Returns(user + "&" + server + "&" + password + "&" + level);
        request.Setup(s => s.User.Identity.IsAuthenticated).Returns(true);
    
        var mockClients = new Mock<IHubCallerConnectionContext>();
        mockClients.Setup(m => m.Group("groupName")).Returns((ExpandoObject)groupName);
    
        var mockGroupManager = new Mock<IGroupManager>();
        var mockHubCallerContext = new Mock<HubCallerContext>(request.Object, connectionId);
    
        var hubMock = new Mock<IHub>();
        hubMock.Setup(p => p.Groups).Returns(mockGroupManager.Object);
        hubMock.Setup(p => p.Context).Returns(mockHubCallerContext.Object);
        hubMock.Setup(p => p.Clients).Returns(mockClients.Object);
    
        var hub = new RepositoryHub()
        {
            Context = mockHubCallerContext.Object,
            Clients = mockClients.Object,
            Groups = mockGroupManager.Object
        };
    
        var testMethod = hub.OnConnected();
        Thread.Sleep(threadSleepTime);
        //or testMethod.Wait();
    
        Assert.IsTrue(IsSendMessageCalled);
    }
