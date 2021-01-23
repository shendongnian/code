    static IsThirdMondayInMay(DateTime date)
    {
        // The first X in a month is always in the range [1, 8)
        // The second X in a month is always in the range [8, 15)
        // The third X in a month is always in the range [15, 22)
        return date.Month == 5 && date.DayOfWeek == DayOfWeek.Monday &&
               date.Day >= 15 && date.Day < 22;
    }
    static IsChristmasEve(DateTime date)
    {
        return date.Month == 12 && date.Day == 24;
    }
