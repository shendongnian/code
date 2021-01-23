    [TestFixture]
    public class ExampleTests
    {
        [SetUp]
        public void ExecuteScenario()
        {
            GrabBucket();
            AddApple();
            AddOrange();
            AddBanana();
        }
        [Test]
        public void ThereShouldBeOneApple()
        {
            Assert.AreEqual(1, Count("Apple"));
        }
        [Test]
        public void ThereShouldBeOneOrange()
        {
            Assert.AreEqual(1, "Orange");
        }
        [Test]
        public void ThereShouldBeOneBanana()
        {
            Assert.AreEqual(1, "Banana");
        }
        [Test]
        public void ThereShouldBeNoPomegranates()
        {
            Assert.AreEqual(0, "Pomegranate");
        }
        private void GrabBucket() { /* do stuff */ }
        private void AddApple() { /* do stuff */ }
        private void AddOrange() { /* do stuff */ }
        private void AddBanana() { /* do stuff */ }
        private int Count(string fruitType)
        {
            // Query the application state
            return 0;
        }
    }
