    public IEnumerable<LocalDateTime> GetDaylightSavingTransitions(DateTimeZone timeZone, int year)
    {
        var yearStart = new LocalDateTime(year, 1, 1, 0, 0).InZoneLeniently(timeZone).ToInstant();
        var yearEnd = new LocalDateTime(year + 1, 1, 1, 0, 0).InZoneLeniently(timeZone).ToInstant();
        var intervals = timeZone.GetZoneIntervals(yearStart, yearEnd);
            
        return intervals.Select(x => x.IsoLocalEnd).Where(x => x.Year == year);
    }
