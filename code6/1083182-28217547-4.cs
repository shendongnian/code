    public static int DaysInMonth(int year, int month)
    {
        // IsLeapYear checks the year argument
        int[] days = IsLeapYear(year)? DaysToMonth366: DaysToMonth365;
        return days[month] - days[month - 1];
    }
