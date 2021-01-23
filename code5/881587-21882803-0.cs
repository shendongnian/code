    namespace MyTests
    {
        [TestFixture]
        public abstract class BaseTestClass
        {
            [Test]
            public void CommonTest()
            {
            }
        }
        [TestFixture]
        public class TestClass1 : BaseTestClass
        {
            [Test]
            public void OtherTest1()
            {
            }
        }
        [TestFixture]
        public class TestClass2 : BaseTestClass
        {
            [Test]
            public void OtherTest2()
            {
            }
        }
    }
