    TimeZoneInfo tz1 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    TimeZoneInfo tz2 = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");
    DateTime today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz1).Date;
    DateTime dt1 = new DateTime(today.Year, today.Month, today.Day, 15, 30, 0); // 3:30 PM
    DateTime dt2 = new DateTime(today.Year, today.Month, today.Day, 19, 30, 0); // 7:30 PM
    TimeSpan elapsed = TimeZoneInfo.ConvertTimeToUtc(dt1, tz1) -
                       TimeZoneInfo.ConvertTimeToUtc(dt2, tz2);
