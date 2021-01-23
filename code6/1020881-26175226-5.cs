        public void TestOddCounter(IOddNumberCounter counter)
        {
            AssertTrue(counter.Count(1, 2, 3, 15), 3);
        }
        public void TestPrimeCounter(IPrimeNumberCounter counter)
        {
            AssertTrue(counter.Count(2, 3, 15, 16), 2);
        }
