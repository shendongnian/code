    IEnumerable<Test> tests = new List<Test>();
    foreach (DateRange range in selectedDateRanges)
    {
        tests = tests.Union(dbContext.GetTestsInDateRange(range.StartDate, range.EndDate));
    }
