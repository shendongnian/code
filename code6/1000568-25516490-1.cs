    private Mock<IMembershipService> membershipServiceMock;
    
    [TestInitialize]
    public void MyTestInitialize()
    {
        membershipServiceMock = new Mock<IMembershipService>();
    }
    
    [TestMethod]
    public void DoSomethingReturnsWhatever()
    {
        var controller = new FooController( membershipServiceMock.Object );
    
        // etc...
    }
