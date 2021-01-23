public static int DaysInWeek(DateTime arrivalDate, int weekNumber, int duration)
{
    // Handle a Saturday as start day
    var daysInFirstWeek = arrivalDate.DayOfWeek == DayOfWeek.Saturday ? 7 : DayOfWeek.Saturday - arrivalDate.DayOfWeek;
    // First week
    if (weekNumber == 1) return Math.Min(duration, daysInFirstWeek);
    // Other week
    var start = daysInFirstWeek + ((weekNumber - 2) * 7);
    return Math.Max(0, Math.Min(7, duration - start));
}
