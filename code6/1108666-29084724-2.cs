    DateTime dt = new DateTime(2015, 03, 29, 01, 58, 00, DateTimeKind.Local);
    DateTime dtEnd = new DateTime(2015, 03, 29, 03, 03, 00, DateTimeKind.Local);
    // I'm putting this here in case you want to work with a different time zone
    TimeZoneInfo tz = TimeZoneInfo.Local; // you would change this variable here
    // Create DateTimeOffset wrappers so the offset doesn't get lost
    DateTimeOffset dto = new DateTimeOffset(dt, tz.GetUtcOffset(dt));
    DateTimeOffset dtoEnd = new DateTimeOffset(dtEnd, tz.GetUtcOffset(dtEnd));
    // Or, if you're only going to work with the local time zone, you can use
    // this constructor, which assumes TimeZoneInfo.Local
    //DateTimeOffset dto = new DateTimeOffset(dt);
    //DateTimeOffset dtoEnd = new DateTimeOffset(dtEnd);
    while (dto < dtoEnd)
    {
        Log(" Localtime " + dto + " converted to UTC is " + dto.ToUniversalTime());
        // Math with DateTimeOffset is safe in instantaneous time,
        // but it might not leave you at the desired offset by local time.
        dto = dto.AddMinutes(1);
        // The offset might have changed in the local zone.
        // Adjust it by either of the following (with identical effect).
        dto = TimeZoneInfo.ConvertTime(dto, tz);
        //dto = dto.ToOffset(tz.GetUtcOffset(dto));
    }
