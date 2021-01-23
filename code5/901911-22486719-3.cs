    using System;
    using System.Linq;
    var totalDays = (int)endTime.Subtract(startTime).TotalDays;
    var days = Enumerable.Range(0, totalDays)
                         .Select(n => startTime.AddDays(n))
                         .ToList();
