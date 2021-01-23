    public IEnumerable<String> EachMonth(DateTime start, DateTime end)
    {
        for(var m = start.Date; m.Date <= end.Date; m = m.AddMonths(1))
            yield return m.ToString("MM/YYYY");
    }
