    string[] times = {"12:00 AM", "12:00 PM", "12:00 AM"};
    const string timePattern = "h:mm tt";
    double totalMillis = 0;
    var prevTimeSpan = new TimeSpan(0);
    foreach (var time in times)
    {
        var parsedDate = DateTime.ParseExact(time, timePattern, null, DateTimeStyles.None);
        var currTimeSpan = parsedDate.TimeOfDay;
        var millis = (prevTimeSpan - currTimeSpan).TotalMilliseconds;
        prevTimeSpan = currTimeSpan;
        totalMillis += millis;
    }
    // 24 hours = 86400000
    Console.WriteLine("Result is more than 24 hours? {0}", totalMillis >= 0 ? "No" : "Yes");
