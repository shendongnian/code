        [Test]
        public void Test_Case_One()
        {
            AssertCurrency(INPUT, EXPECTED);
        }
        [Test]
        public void Test_Case_Two()
        {
            AssertCurrency(INPUT, EXPECTED);
        }
        private void AssertScenario(int input, int expected)
        {
            Assert.AreEqual(expected, input);
        }
