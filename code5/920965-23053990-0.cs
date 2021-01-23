    [TestMethod()]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DivideTest()
        {
            DivisionClass target = new DivisionClass();
            int numerator = 4;
            int denominator = 0;
            int actual;
            actual = target.Divide(numerator, denominator);
        }
