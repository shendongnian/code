    [TestMethod]
    public void TestOne()
    {
        CollectionAssert.AreEqual(ExpectedList(), PrimeFactorGenerator.Generate(1));
    }
