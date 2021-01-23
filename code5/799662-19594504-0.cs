    var minStartDate = dateRanges.Min(r => r.StartDate);
    var maxEndDate = dateRanges.Max(r => r.EndDate);
    var tests = (from test in dbContext.Tests
                where minStartDate <= test.Date && maxEndDate >= test.Date
                select test)
                .AsEnumerable()  // change to Linq-To-Objects
                .Where(test => dateRanges.Any(range => range.StartDate <= test.Date 
                                                       && range.EndDate >= test.Date));
