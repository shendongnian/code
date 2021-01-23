    from result in results
    group result by new { result.Year, result.Month, result.Day, result.Hour, result.Minute }
        into g
        select new
        {
           DocumentID = Guid.NewGuid(),
           Year = g.Key.Year,
           Month = g.Key.Month,
           Day = g.Key.Day,
           Hour = g.Key.Hour,
           Minute = g.Key.Minute,
           RequestBytes = (Int32)g.Sum(r => r.RequestBytes),
           ResponseBytes = (Int32)g.Sum(r => r.ResponseBytes),
           TotalRequests = (Int32)g.Sum(r => r.TotalRequests)
        }
