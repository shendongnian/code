    UnitOfWork.Query<WorkoutRecord>()
        .Where(x => x.WorkoutDate > baseDate && x.TotalTicks > 600)
        .GroupBy(x => EntityFunctions.TruncateTime(x.UploadDate))
        .Select(x => new 
        {
            Date = x.Key ?? DateTime.UtcNow,
            TheCount = x.Count()
        })
        .GroupBy(x=> SqlFunctions.DatePart("weekday", x.Date))
        .Select (x => new AdminDashboardWorkoutsGroupedDay()
        {
            WorkoutCount = (x.Average(y=>y.TheCount)),
            DayOfWeek = (DayOfWeek)x.Key
        })
        .ToList()
