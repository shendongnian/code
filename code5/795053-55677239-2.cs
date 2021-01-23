    using System.Linq
    ...
    [TestCase(new [] {1}, 1)]
    [TestCase(new [] {1, 2}, 3)]
    [TestCase(new [] {1, 2, 3}, 6)]
    public void Return_sum_of_numbers(int[] numbers, int expectedSum)
    {
        var sum = CalculatorLibrary.CalculatorFunctions.Add(numbers.ToList());
        Assert.AreEqual(expectedSum, sum );
        // much cooler with FluentAssertions nuget:
        // sum.Should.Be(expectedSum);
    }
