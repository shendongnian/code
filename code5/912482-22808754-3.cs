    private static DateTime GetDateTime(int year, int month, DayOfWeek dayofweek, int weekofmonth, StartingWeek start = StartingWeek.WeekBeginWithSunday)
    {
        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        // ajust calcul with starting day on the week
        int delta = start == StartingWeek.WeekBeginWithMonday ? 1 : 0;
        int durationOfFirstWeek = (7 - (int)firstDayOfMonth.DayOfWeek + delta) % 7;
        int day = durationOfFirstWeek + (weekofmonth - 2) * 7 + ((int)dayofweek + 7 - delta) % 7 + 1;
        // day is on the previous month
        if (day <= 0)
        {
            return new DateTime(year, month, 1);
        }
        if (day <= DateTime.DaysInMonth(year, month))
        {
            return new DateTime(year, month, day);
        }
        // day is on next month
        return new DateTime(year, month, DateTime.DaysInMonth(year, month));
    }
