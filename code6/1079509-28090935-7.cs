    [Test]
    public void Constructor_Always_Succeeds()
    {
        var mockOfB = new Mock<B>();
        var mockOfA = mockOfB.As<A>();
        DateTime dateTime = DateTime.Now;
        mockOfA.SetupGet(p => p.DateCreated).Returns(dateTime);
        mockOfB.SetupGet(p => p.DateCreated).Returns(dateTime);
        B b = mockOfB.Object;
        A a = b;
        Assert.That(b.DateCreated, Is.EqualTo(dateTime));
        Assert.That(a.DateCreated, Is.EqualTo(dateTime));
    }
