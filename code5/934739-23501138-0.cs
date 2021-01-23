    public DateTime ConvertToIndiaStandardTime(DateTime dateTime, int offsetMinutes)
    {
        // Create a DateTimeOffset from the input values.
        // This assumes positive offset values are *WEST* of UTC,
        // such as if it came from the getTimeZoneOffset function of
        // JavaScript's Date object.
        TimeSpan offset = TimeSpan.FromMinutes(-offsetMinutes);
        DateTimeOffset dto = new DateTimeOffset(dateTime, offset);
        // Convert the DateTimeOffset to the desired time zone
        DateTimeOffset converted =
            TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dto, "Indian Standard Time");
        // Return the DateTime portion, representing the local time in India.
        return converted.DateTime;
    }
