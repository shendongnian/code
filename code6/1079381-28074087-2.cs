    [TestMethod]
    public void TestOne()
    {
        CollectionAsssert.AreEquivalent(ExpectedList(), PrimeFactorGenerator.Generate(1));
    }
