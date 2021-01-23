    [TestCase(new [] {1}, 1)]
    [TestCase(new [] {2, 3}, 5)]
    [TestCase(new [] {1000}, 1000)]
    public void Add_WithOneNumber_ReturnsNumber(int[] numbers, int expectedResult)
    {
        var result = CalculatorLibrary.CalculatorFunctions.Add(numbers.ToList());
        Assert.AreEqual(expectedResult, result);
    }
