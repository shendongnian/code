    [TestFixture]
    public class BarTests
    {
        [Test]
        public void BarFooDoesStuff()
        {
            var expected = 9999999;
            var fakeBar = A.Fake<IBar>();
            A.CallTo(fakeBar)
                .Where(call => call.Method.Name == "Foo")
                .WithReturnType<int>()
                .Returns(expected);
            var response = fakeBar.Foo<bool>();
            Assert.AreEqual(expected, response);
        }
    }
