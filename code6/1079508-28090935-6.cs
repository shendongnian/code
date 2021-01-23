    [Test]
    public void Constructor_Always_Succeeds()
    {
        var mockOfB = new Mock<B>();
        var mockOfA = mockOfB.As<A>();
        mockOfA.SetupProperty(p => p.DateCreated);
        B b = mockOfB.Object;
        A a = b;
        DateTime aTime = DateTime.Now;
        DateTime bTime = DateTime.Now.AddDays(-1);
        a.DateCreated = aTime;
        Assert.That(a.DateCreated, Is.EqualTo(aTime));
        Assert.That(b.DateCreated, Is.EqualTo(aTime));
        b.DateCreated = bTime;
        Assert.That(a.DateCreated, Is.EqualTo(bTime));
        Assert.That(b.DateCreated, Is.EqualTo(bTime));
    }
