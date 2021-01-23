    public static void proof()
    {
        DateTime date = DateTime.MinValue;
        DateTime max_date = DateTime.MaxValue.AddDays(-1);
        while (date < max_date)
        {
            if (date.DayOfWeek != date.dayOfWeekTurbo())
            {
                Console.WriteLine("{0}\t{1}", date.DayOfWeek, date.dayOfWeekTurbo());
                Console.ReadLine();
            }
            date = date.AddDays(1);
        }
    }
