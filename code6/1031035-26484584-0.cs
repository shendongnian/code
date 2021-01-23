    DateTime oneMonthAgo = DateTime.Today.AddMonths(-1);
    DateTime start = oneMonthAgo.AddDays(1 - oneMonthAgo.Day);
    DateTime end = start.AddMonths(1);
    var passengerCount = db.CountPassengerManifestViews
                           .Count(c => c.DepartureDate >= start &&
                                       c.DepartureDate < end);
