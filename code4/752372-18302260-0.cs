    [Test]
    [TestCase("5*5", 25)]
    [TestCase("5*5*5", 125)]
    [TestCase("5+5", 10)]
    // etc
    public void Parse_SimpleValues_Calculated(string input, int expectedOutput)
    {
        Assert.AreEqual(expectedOutput, test.ParseCalculationString(input));
    }
