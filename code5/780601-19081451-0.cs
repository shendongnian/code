    var months = bookings
        .AsEnumerable()
        .Select(c => new { 
            MonthId = c.ActualEta.Value.Month,
            MonthName = c.ActualEta.Value.Month.ToString("MMMM")
        }).ToList();
