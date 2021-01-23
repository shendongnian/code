    private static void Main(string[] args)
    {
        DateTime date = new DateTime(2014, 12, 1);
        var firstAndLastDays = getFirstDateInDatePicker(date);
    }
    
    private static Tuple<int, int> getFirstDateInDatePicker(DateTime date)
    {
        int totalDaysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        int totalDiff = TOTAL_DAYS - totalDaysInMonth;
        DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, totalDaysInMonth);
        int subtractor = (6 + (int)firstDayOfMonth.DayOfWeek) * -1;
        return new Tuple<int, int>(firstDayOfMonth.AddDays(subtractor).Day,
            lastDayOfMonth.AddDays(totalDiff + subtractor).Day);
    }
