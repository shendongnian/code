    DateTime nextWednesday = DateTime.Now.AddDays(1);
    while (nextWednesday.DayOfWeek != DayOfWeek.Wednesday)
        nextWednesday = nextWednesday.AddDays(1);
    DateTime lastWednesday = DateTime.Now.AddDays(-1);
    while (lastWednesday.DayOfWeek != DayOfWeek.Wednesday)
        lastWelastWednesday.AddDays(-1);
