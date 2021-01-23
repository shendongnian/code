    [TestFixture]
    [Property("type", "smoke")]
    public class ContextText
    {
        private TestContext _fixtureContext;
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _fixtureContext = TestContext.CurrentContext;
        }
        [TestCase]
        public void TestFixtureContextTest()
        {
            // This succeeds
            Assert.That(_fixtureContext.Test.Properties["type"], Is.EqualTo("smoke"));
        }
        [TestCase]
        public void TestCaseContextTest()
        {
            // This fails
            Assert.That(TestContext.CurrentContext.Test.Properties["type"], Is.EqualTo("smoke"));
        }
    }
