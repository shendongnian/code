    using System;
    using System.Linq;
    int totalDays = endTime.Subtract(startTime).TotalDays;
    List<DateTime> days = new List<DateTime>();
    Enumerable.Range(0, totalDays).Select(n => days.Add(startTime.AddDays(n)));
