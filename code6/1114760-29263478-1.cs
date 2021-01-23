    // A timespan isn't really a time-of-day, but we'll let that slide for now.
    TimeSpan time = new TimeSpan(18, 00, 00);
    // Use the current utc date, at that time.
    DateTime utcDateTime = DateTime.UtcNow.Date.Add(time);
    // Convert to the US Eastern time zone.
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    DateTime easternDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tz);
