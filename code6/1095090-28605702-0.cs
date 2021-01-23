    private void DoBatch(DateTime from, DateTime to)
        {
            TimeSpan between = to - from;
            var dateRanges = Enumerable.Range(0, between.Days)
                                .Select(d =>
                                {
                                    var dt = from.AddDays(d);
                                    return new
                                    {
                                        day = d,
                                        date = dt,
                                        startDate = dt.StartOfDay(),
                                        endOfDate = dt.EndOfDay()
                                    };
                                })
                                .Select(x => {
                                    return new
                                    {
                                        startDate = x.startDate < from ? from : x.startDate,
                                        endDate = x.endOfDate > to ? to : x.endOfDate
                                    };
                                })
                                .ToArray();
        }
