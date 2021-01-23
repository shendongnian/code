    // Framework code creates the DateTime.
    var sourceDateTime = DateTime.Parse("2013-10-15T12:54:18+01:00");
    // Application code can further process the DateTime.
    var destinationTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
    var destinationDateTime = TimeZoneInfo.ConvertTime(sourceDateTime, destinationTimeZoneInfo);
