    public IEnumerable<DateTime> GetTimeRange(DateTime startTime, DateTime endTime, int minutesBetween)
    {
       int periods = (int)(endTime - startTime).TotalMinutes / minutesBetween;  
       return Enumerable.Range(0,periods+1)
                        .Select (p => startTime.AddMinutes(minutesBetween * p));
    }
