    public IEnumerable<DateTime> IntervalDays(DateTime start, DateTime end)
    {
        if (start > end)
            yield break;
    
        var d = start.Date;
              
        while (d <= end.Date)
        {
            yield return d;
            d = d.AddDays(1);
        }
    }
