    string[] times = { "12:00 AM", "12:00 PM", "12:05 AM" };
    const string timePattern = "h:mm tt";
    TimeSpan prev = TimeSpan.Zero;
    var spans = times.Select(x =>
    {
        var span = DateTime.ParseExact(x, timePattern, null, DateTimeStyles.None).TimeOfDay;
        if (span < prev)
        {
            span = span.Add(TimeSpan.FromDays(1.0) - prev);
        }
        prev = span;
        return span;
    });
    var totalMillis = spans.Sum(x => x.TotalMilliseconds);
    // 24 hours = 86400000
    Console.WriteLine("Result is more than 24 hours? {0}", totalMillis >= 86400000 ? "Yes" : "No");
