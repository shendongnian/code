    IQueryable<Result> allResults = MyRepository.RetrieveAll();
    
    var resultGroup = allResults.OrderByDescending(r => r.DatePosted)
    											   .Skip(60)
    											   .Take(30)
    											   .GroupBy(p => new {Total = allResults.Count()})
    											   .First();
    
    var results = new ResultObject
    {
    	ResultCount = resultGroup.Key.Total,
    	Results = resultGrouping.Select(r => r)
    };
