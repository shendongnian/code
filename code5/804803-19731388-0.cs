    select new TimeBand()
    {
        Region = grp.Key.Region,
        DayName = grp.Key.DayName,
        StartDates = grp.Select(x => x.StartDate),
        EndDates = grp.Select(x => x.EndDate)
    }
