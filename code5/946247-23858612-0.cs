    using FluentAssertions;
    [TestClass]
    public class SomeTests
    {
        [TestMethod]
        public void TestTransitiveDependencies() 
        {
            C.CFoo.BFoo.str.Should().Be("afoo");
        }
    }
