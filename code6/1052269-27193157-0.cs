    [Test, TestCaseSource("GetTestCaseSource")]
    public void SaveBookingTest(int numberOfItems)
    {
        var stopwatch = new Stopwatch();
    
        var items = DataFactory.CreateItems(numberOfItems);
    
        stopwatch.Start();
        service.SaveItems(items);
        stopwatch.Stop();
    
        SaveResults(stopwatch.ElapsedMilliseconds);
    }
    
    public IEnumerable<int> GetTestCaseSource()
    {
        return new[] { 1, 10, 100, 1000 };
    }
