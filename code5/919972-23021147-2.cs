    [Test]
    [TestCase("Exceeds", "Exceeds", new string[] { "AHT", "QA" })]
    [TestCase("NoMatch", "NoMatch", new string[] { null, null })]
    [TestCase("Exceeds", "NoMatch", new string[] { "AHT", null })]
    [TestCase("NoMatch", "Exceeds", new string[] { null, "QA" })]
    public void CalculatePointsTest(string kpiA, string kpiB, string[] expected)
    {
    	CollectionAssert.AreEqual(expected, CalculatePoints(kpiA, kpiB));
    }
