    private static readonly LocalTimePattern TimePattern = 
        LocalTimePattern.CreateWithInvariantCulture("hh:mm:ss tt");
    // TODO: Check this is what you want! We can't tell from your example.
    private static readonly LocalDatePattern DatePattern =
        LocalDatePattern.CreateWithInvariantCulture("dd/MM/yyyy");
    private static readonly LocalDateTimePattern DateTimePattern =
        LocalDatePattern.CreateWithInvariantCulture("yyyy-MM-dd HH:mm:ss");
    public static string GetMergedDateTime(string dateText, string timeText)
    {
        // The Value property throws an exception if parsing failed. You can
        // check that with the Success property first though.
        LocalDate date = DatePattern.Parse(dateText).Value;
        LocalTime time = TimePattern.Parse(timeText).Value;
        LocalDateTime dateTime = date + time;
        return DateTimePattern.Format(dateTime);
    }
