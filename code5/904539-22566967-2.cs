    public class PolymorphicKeysTests
    {
        public PolymorphicKeysTests()
        {
        }
        private Dictionary<Key, string> dict;
        [TestInitialize]
        public void TestInitialize()
        {
            dict = new Dictionary<Key, string>();
            dict[new Key("A")] = "Data A";
            dict[new CarKey("B")] = "Data B";
            dict[new CoupeKey("B")] = "Data B1";
            dict[new CoupeKey("C")] = "Data C";
        }
        [TestMethod]
        public void CoupeKeyB()
        {
            Assert.AreEqual("Data B1", dict.MostRelevantData(new CoupeKey("B")));
        }
        [TestMethod]
        public void CoupeKeyA()
        {
            Assert.AreEqual("Data A", dict.MostRelevantData(new CoupeKey("A")));
        }
        [TestMethod]
        public void CoupeKeyC()
        {
            Assert.AreEqual("Data C", dict.MostRelevantData(new CoupeKey("C")));
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void CarKeyC()
        {
            dict.MostRelevantData(new CarKey("C"));
        }
        [TestMethod]
        public void CarKeyB()
        {
            Assert.AreEqual("Data B", dict.MostRelevantData(new CarKey("B")));
        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void VanKeyC()
        {
            dict.MostRelevantData(new VanKey("C"));
        }
        [TestMethod]
        public void VanKeyB()
        {
            Assert.AreEqual("Data B", dict.MostRelevantData(new VanKey("B")));
        }
    }
