    var query = (from x in bands
                         group x by new { x.Region, x.DayName }
                             into grp
                             select new 
                             {
                                 Region = grp.Key.Region,
                                 DayName = grp.Key.DayName,
                                 MinStartDate = grp.Min(x => x.StartDate),
                                 AllStartDates = grp.Select(k => k.StartDate).ToList(),
                                 EndDate = grp.Max(x => x.EndDate),
                                 AllEndDates = grp.Select(k => k.EndDate).ToList(),
                             }).ToList();
