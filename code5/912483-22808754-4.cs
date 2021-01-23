    private static void Main(string[] args)
    {
        int year = 2014;
        int month = 10;
        DayOfWeek dayofweek = DayOfWeek.Saturday;
        int weekofmonth = 2;
        DateTime date = GetDateTime(year, month, dayofweek, weekofmonth);
        Console.WriteLine(date.ToShortDateString());
        DateTime date2 = GetDateTime(year, month, DayOfWeek.Monday, 1, StartingWeek.WeekBeginWithMonday);
        Console.WriteLine(date2.ToShortDateString());
        DateTime date2b = GetDateTime(year, month, DayOfWeek.Saturday, 1, StartingWeek.WeekBeginWithMonday);
        Console.WriteLine(date2b.ToShortDateString());
        DateTime date2c = GetDateTime(year, month, DayOfWeek.Saturday, 2, StartingWeek.WeekBeginWithMonday);
        Console.WriteLine(date2c.ToShortDateString());
        DateTime date2d = GetDateTime(year, month, DayOfWeek.Sunday, 1, StartingWeek.WeekBeginWithMonday);
        Console.WriteLine(date2d.ToShortDateString());
        DateTime date2e = GetDateTime(year, month, DayOfWeek.Sunday, 2, StartingWeek.WeekBeginWithMonday);
        Console.WriteLine(date2e.ToShortDateString());
        DateTime date3 = GetDateTime(year, month, DayOfWeek.Saturday, 5, StartingWeek.WeekBeginWithMonday);
        Console.WriteLine(date3.ToShortDateString());
           
        Console.ReadLine();
    }
