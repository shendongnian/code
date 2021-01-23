    public static DateTime FirstDateOfWeek(DateTime date)
    {
        // Since Sunday = 0 and we want sunday to be the first day of week:
        int dayOfWeek = (int)date.DayOfWeek;
        return date.AddDays(-dayOfWeek);
    }
