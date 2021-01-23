    List<DateTime> saturdays = new List<DateTime>();
    for (int i = -13; i < 4; i++)
        saturdays.Add(DateTime.Now.AddDays(i * 7 - (DateTime.Now.DayOfWeek - DayOfWeek.Saturday)));
    DateTime today = DateTime.Now;
    var more_recent = saturdays.OrderBy(day => Math.Abs(today.Subtract(day).Days)).ToList();
