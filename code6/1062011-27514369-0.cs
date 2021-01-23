    public class BusinessLogicClass
    {
        public void MethodUnderTest(IFoo foo)
        {
            foo.Bar -= 1;
        }
    }
    
    public interface IFoo
    {
        int Bar { get; set; }
    }
    
    public class Foo : IFoo
    {
        public int Bar { get; set; }
    }
    
    [TestMethod]
    public void PropertyTest()
    {
        const int expected = 41;
        var foo = new Foo { Bar = 42 };
        var sut = new BusinessLogicClass();
        sut.MethodUnderTest(foo);
        Assert.AreEqual(expected, foo.Bar);
    }
    
    [TestMethod]
    public void PropertyTestWithMoq()
    {
        var fooMoq = new Mock<IFoo>();
        var sut = new BusinessLogicClass();
        sut.MethodUnderTest(fooMoq.Object);
        fooMoq.Verify(x => x.Bar, Times.Once);
    }
