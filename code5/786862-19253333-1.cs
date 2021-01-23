    public static DateTime ConvertToUtc(DateTime dateTime, int offsetInMinutes)
    {
        var offset = Offset.FromMinutes(offsetInMinutes);
        var localDateTime = LocalDateTime.FromDateTime(dateTime);
        return new OffsetDateTime(localDateTime, offset).ToInstant()
                                                        .ToDateTimeUtc();
    }
