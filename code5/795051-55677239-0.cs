    [TestCase(new [] {1}, 1)]
    [TestCase(new [] {2}, 2)]
    [TestCase(new [] {1000}, 1000)]
    public void Add_WithOneNumber_ReturnsNumber(int[] numbers)
    {
        var result = CalculatorLibrary.CalculatorFunctions.Add(numbers);
        Assert.AreEqual(1, result.ToList());
    }
