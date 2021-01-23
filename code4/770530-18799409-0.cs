    // These should be stored in UTC.  Do not store them in anyone's local time.
    item.CreatedDate = DateTime.UtcNow;
    item.UpdatedDate = DateTime.UtcNow;
    // Then later when you want to convert to a specific time zone, do this
    string timeZoneId = "India Standard Time"; // as an example
    TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    DateTime localCreated = TimeZoneInfo.ConvertTimeFromUtc(item.CreatedDate, timeZone);
    DateTime localUpdated = TimeZoneInfo.ConvertTimeFromUtc(item.UpdatedDate, timeZone);
