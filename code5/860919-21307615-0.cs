    List<DateTime> satsAndSundays;
    for (DateTime temp = start; temp <= end; temp.AddDays(1))
    {
        if (temp.DayOfWeek == DayOfWeek.Sunday || temp.DayOfWeek == DayOfWeek.Saturday)
        {
            satsAndSundays.add(temp);
        }
    }
