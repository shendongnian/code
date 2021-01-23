        [TestMethod()]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes=true)]
        public void DivideTest()
        {
            int numerator = 4;
            int denominator = 0;
            int actual = numerator / denominator;
        }
