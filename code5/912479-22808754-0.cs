    private static DateTime GetDateTime(int year, int month, int dayofweek, int weekofmonth)
    {
        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        int durationOfFirstWeek = 8 - (int)firstDayOfMonth.DayOfWeek;
        int day = durationOfFirstWeek + (weekofmonth - 2) * 7 + dayofweek;
        // day is on the previous month
        if (day <= 0)
        {
            return new DateTime(year, month, 1);
        }
        if (day <= DateTime.DaysInMonth(year, month))
        {
            return new DateTime(year, month, durationOfFirstWeek + (weekofmonth - 2) * 7 + dayofweek);
        }
        // day is on next month
        return new DateTime(year, month, DateTime.DaysInMonth(year, month));
    }
