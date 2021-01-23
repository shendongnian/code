        [Test()]
        public void TestNegativePadding()
        {
            int number1 = 123;
            int number2 = -123;
            Assert.AreEqual("00000123", string.Format("{0:D8}", number1));
            Assert.AreEqual("-00000123", string.Format("{0:D8}", number2));
        }
