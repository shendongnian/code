    public AverageReturnArgs GetAverage(List<Log> logs, DateTime TimeReq)
    {
        int hour = TimeReq.Hour;
        int min = TimeReq.Minute;
        var average = logs
        .Where(log => log.TimeStamp.Hour == hour && log.TimeStamp.Minute == min)
        .GroupBy(grp => grp.TimeStamp)
        .Select(av => new AverageReturnArgs()
        {
            Hour = hour,
            Minute = min,
            Count = av.Average(x => av.Count(y=>y.HasExtraBaggageSpace))
        });
    }
