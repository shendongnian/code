    [TestFixture]
    public class ExpressNotTests
    {
        [Test]
        public void GenerateFieldDoesNotStartsWithExpression_DoesNotStartWith_True()
        {
            var a = new TestClass() {TestString = "Not"};
            var exp = GenerateFieldDoesNotStartsWithExpression<TestClass>("TestString", "Test");
            
            var res = exp.Compile()(a);
            res.Should().BeTrue();
        }
        [Test]
        public void GenerateFieldDoesNotStartsWithExpression_DoesStartsWith_False()
        {
            var a = new TestClass() {TestString = "TestString"};
            var exp = GenerateFieldDoesNotStartsWithExpression<TestClass>("TestString", "Test");
            
            var res = exp.Compile()(a);
            res.Should().BeFalse();
        }
        private class TestClass
        {
            public string TestString { get; set; }
        }
    }
