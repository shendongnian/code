    int year = 2015;
    for (int i = 1; i < 13; i++)
    {
         if(new DateTime(year, i, 13).DayOfWeek == DayOfWeek.Friday)
           Console.WriteLine(new DateTime(year, i, 13));
    }
