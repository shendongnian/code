    public class Example : IExample { public string data { get; private set; } }
    public interface IExample { string data { get; } }
    [TestMethod]
    public void One()
    {
        var fakeExample = NSubstitute.Substitute.For<IExample>();
        fakeExample.data.Returns("FooBar");
        Assert.AreEqual("FooBar", fakeExample.data);
    }
