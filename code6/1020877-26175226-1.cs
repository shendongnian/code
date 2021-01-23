        public void TestOddCounter(IOddCounter counter)
        {
            AssertTrue(counter.Count(1, 2, 3, 15), 3);
        }
        public void TestPrimeCounter(IPrimeCounter counter)
        {
            AssertTrue(counter.Count(2, 3, 15, 16), 2);
        }
