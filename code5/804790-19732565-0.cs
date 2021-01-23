    public interface IFoo
    {
        int Do();
    }
    [Test]
    public void ThrowsFirstTime()
    {
        var fakeFoo = A.Fake<IFoo>();
        A.CallTo(() => fakeFoo.Do()).Returns(1);
        A.CallTo(() => fakeFoo.Do()).Throws<Exception>().Once();
    
        Assert.Throws<Exception>(()=>fakeFoo.Do());
        int t = fakeFoo.Do();
    
        A.CallTo(() => fakeFoo.Do()).MustHaveHappened(Repeated.Exactly.Twice);
        Assert.That(t, Is.EqualTo(1));
    }
