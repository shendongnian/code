    DateTime end = start;
    for (int i = x; i >= 0;) // the third parameter of the for is empty on purpose
    {
        end = end.AddDays(1);
        if (end.DayOfWeek != DayOfWeek.Saturday &&
            end.DayOfWeek != DayOfWeek.Sunday)
        {
            i--;
        }
    }
