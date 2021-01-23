    [Test]
    [TestCase(new[] { 0 }, 0)]
    public void Sum_Is_Calculated_Correctly_When_Entries_Supplied(int[] data, int expected)
    {
        var bomManager = new BomManager();
        Assert.AreEqual(expected, bomManager.MethodToTest(new Collection<int>(data)));
    }
