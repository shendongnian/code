	[TestFixture]
    public class SampleFixture {
        private class TestMyClass : MyClass {
            public TestMyClass(int i) : base(i) { }
            // ... stub/no-op implementations of any abstract members ...
        }
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidConstructorArgUsingSubclass()
        {
            new TestMyClass(-5);
        }
        // Aside: I think `Assert.Throws` is preferred over `ExpectedException` now.
        // See http://stackoverflow.com/a/15043731/906
	}
