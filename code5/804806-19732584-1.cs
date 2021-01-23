    var query = from x in bands
                group x by new
                           {
                               x.Region,
                               x.DayName
                           }
                into grp
                select new TimeBand()
                       {
                           Region = grp.Key.Region,
                           DayName = grp.Key.DayName,
                           StartDate = grp.Min(x => x.StartDate),
                           StartTime = grp.Min(x => x.GetStart()).ToShortTimeString(),
                           EndDate = grp.Max(x => x.EndDate),
                           EndTime = grp.Max(x => x.GetEnd()).ToShortTimeString(),
                       };
