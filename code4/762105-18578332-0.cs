    class Foo
    {
        private string value;
        public Foo(string val)
        {
            this.value = val;
        }
        public static implicit operator Foo(string value)
        {
            return new Foo(value);
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Foo a = "asdf";
            Foo b = "asdf";
            Assert.AreNotEqual(a, b);
        }
    }
