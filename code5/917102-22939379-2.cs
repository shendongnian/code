    DateTime incidentStart = new DateTime(2014, 04, 06, 11, 30, 0, 0, 0);
    DateTime incidentEnd = new DateTime(2014, 04, 08, 10, 15, 0, 0, 0);
    int minutes =  (int)(incidentEnd - incidentStart).TotalMinutes;
    decimal numHours = Enumerable.Range(0, minutes)
        .Select(min => incidentStart.AddMinutes(min))
        .Where(dt => dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday 
           &&  dt.TimeOfDay >= TimeSpan.FromHours(9) && dt.TimeOfDay <= TimeSpan.FromHours(17))
        .GroupBy(dt => new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, 0)) // round to hour
        .Count();
