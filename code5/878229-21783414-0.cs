    [Test]
    public void x()
    {
        var o = Substitute.For<anything>();
        o.GetHashCode().Returns(3);
        Assert.AreEqual(4, o.GetHashCode());
    }
