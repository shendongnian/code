    public static List<DateTime> GetDatesWithoutWeekends(List<DateTime> dates)
    {
        return
            dates.Where(date => (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday))
                    .ToList();
    }
