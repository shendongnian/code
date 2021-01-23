    foreach (WeekDays day in Enum.GetValues(typeof(WeekDays))
    {
        if (days & day != 0)
        {
            Console.WriteLine("Got {0}", day);
        }
    }
