        [TestMethod()]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivideTest()
        {
            int numerator = 4;
            int denominator = 0;
            int actual = numerator / denominator;
        }
