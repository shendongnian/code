    ...
    public void test_bar_does_bar() {
        var foo = new Mock<IFoo>();
        foo.Setup(f => f.HasFooage).Returns(true);
        var bar = new Mock<IBar>();
        var stuff = new Stuff(foo.Object, bar.Object);
    
        stuff.DoStuff();
    
        Assert.That(bar.Bar, Is.EqualTo(4));
    }
