    public static LocalDate GetDay(int year, int month, IsoDayOfWeek dayOfWeek,
                                                                        int instance)
    {
        int daysInMonth = CalendarSystem.Iso.GetDaysInMonth(year, month);
        var ld = new LocalDate(year, month, 1);
        if (ld.IsoDayOfWeek != dayOfWeek)
            ld = ld.Next(dayOfWeek);
        for (int i = 1; i < instance && ld.Day + 7 <= daysInMonth; i++)
            ld = ld.PlusWeeks(1);
        return ld;
    }
