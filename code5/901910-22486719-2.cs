    using System;
    using System.Linq;
    int totalDays = endTime.Subtract(startTime).TotalDays;
    var days = Enumerable.Range(0, totalDays)
                         .Select(n => days.Add(startTime.AddDays(n)))
                         .ToList();
