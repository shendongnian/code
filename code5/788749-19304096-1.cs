    string[] times = { "12:00 AM", "12:00 PM", "12:05 AM" };
    const string timePattern = "h:mm tt";
    DateTime[] dates = times.Select(x => DateTime.ParseExact(x, timePattern, null)).ToArray();
    TimeSpan totalTimeSpan = new TimeSpan();
    for (int i = 1; i < dates.Length; i++)
    {
        // Assume that each time is at least the same date as the previous time
        dates[i] = dates[i - 1].Date + dates[i].TimeOfDay;
        // If this time is earlier than the previous time then assume it must be on the next day
        if (dates[i - 1].TimeOfDay > dates[i].TimeOfDay)
            dates[i] = dates[i].AddDays(1);
        totalTimeSpan += dates[i] - dates[i - 1];
    }
    Console.WriteLine("Result is more than 24 hours? {0}", totalTimeSpan.TotalHours > 24);
