        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void DivideTest()
        {
            int numerator = 4;
            int denominator = 0;
            int actual = numerator / denominator;
        }
