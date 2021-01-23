    public static DateTime GetFirstBussinessDayInMonth(int month, int year, DateTime[] holidays)
    {
        return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                         .Select(day => new DateTime(year, month, day))
                         .Where(dt => dt.DayOfWeek != DayOfWeek.Sunday
                                      && dt.DayOfWeek != DayOfWeek.Saturday
                                      && (holidays == null || !holidays.Any(h => h.Equals(dt))))
                         .Min(d => d.Date);
    }
