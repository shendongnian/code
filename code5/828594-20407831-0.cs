    DateTime nextWednesday = DateTime.Now.AddDays(1);
    while (nextWednesday.DayOfWeek != DayOfWeek.Wednesday)
        nextWednesday.AddDays(1);
    DateTime lastWednesday = DateTime.Now.AddDays(-1);
    while (lastWednesday.DayOfWeek != DayOfWeek.Wednesday)
        lastWednesday.AddDays(-1);
