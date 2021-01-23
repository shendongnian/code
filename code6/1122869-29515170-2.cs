    int year = 2014;
    DateTime day = new DateTime(2014,1,1);
    while (day.Year == year)
    {
        if (day.DayOfWeek == DayOfWeek.Friday && day.Day == 13)
        {
            Console.WriteLine(day);
        }
        day = day.AddDays(1);
    }
