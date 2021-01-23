    public List<PivotedMean> AssociateResultsWithCollectionDate(List<MeanData> meanData)
    {
       
        var currentMonth = DateTime.Now.Month;
        return meanData
            .GroupBy(i => i.Description)
            .Select(g => new PivotedMean // notice the class name here
            { // this is now a PivotedMean initializer
                Description = g.Key, // You were also missing some caps here
                Month3 = g.Where(c => c.CollPeriod.Month == currentMonth - 3),
                Month2 = g.Where(c => c.CollPeriod.Month == currentMonth - 2),
                Month1 = g.Where(c => c.CollPeriod.Month == currentMonth - 1)
            }).ToList(); // notice the ToList
    }
