    for (int i = -13; i <= 4; i++)
    {
        var dateBackWithIWeeks = DateTime.Now.AddDays(i * 7);
        switch (dateBackWithIWeeks.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                dateBackWithIWeeks = dateBackWithIWeeks.AddDays(-1);
                break;
            case DayOfWeek.Monday:
                dateBackWithIWeeks = dateBackWithIWeeks.AddDays(5);
                break;
            case DayOfWeek.Tuesday:
                dateBackWithIWeeks = dateBackWithIWeeks.AddDays(4);
                break;
            case DayOfWeek.Wednesday:
                dateBackWithIWeeks = dateBackWithIWeeks.AddDays(3);
                break;
            case DayOfWeek.Thursday:
                dateBackWithIWeeks = dateBackWithIWeeks.AddDays(2);
                break;
            case DayOfWeek.Friday:
                dateBackWithIWeeks = dateBackWithIWeeks.AddDays(1);
                break;
            case DayOfWeek.Saturday:
                break;
        }
        Console.WriteLine(dateBackWithIWeeks.Date);
    }
