    double resolutionInMins = 30; // In minites
    double divisor = to.Now.AddMinutes(resolutionInMins).Ticks - to.Now.Ticks;
    Func<DateTime, double> resolutionLevel = 
        delegate(DateTime timestamp)
    {
        return Math.Ceiling((to.Now.Ticks - timestamp.Ticks) / divisor);
    };
    var query =
        Session.Query<SomeEvent>()
        .Where(p => 
            p.Timestamp >= from.Now && 
            p.Timestamp <= to.Now)
        .GroupBy(x => new 
        {
            ResolutionLevel = resolutionLevel(x.Timestamp), 
            Timestamp = x.Timestamp 
        })
        .Select(x => new SomeEvent
        {
            ResolutionLevel = x.Key.ResolutionLevel,
            Timestamp = x.Key.Timestamp,
            DisplayValue = x.Average(b => b.DisplayValue)
        });
