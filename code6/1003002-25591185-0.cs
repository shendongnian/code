     public AverageReturnArgs GetAverage(List<Log> logs, DateTime TimeReq)
    {
        int hour = TimeReq.Hour;
        int min = TimeReq.Minute;
        var average = logs.GroupBy(grpByHourMin => new
        {
            hour = grpByHourMin.TimeStamp.Hour,
            min = grpByHourMin.TimeStamp.Minute,
            count = grpByHourMin.Count(x=>x.HasExtraBaggageSpace)
        }).Select(av => new AverageReturnArgs()
        {
            Hour = av.Key.hour,
            Minute = av.Key.min,
            Count = av.Average(x => x.count)
        });
    }
