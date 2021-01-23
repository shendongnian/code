    public static void benchDayOfWeek()
    {
        DateTime[] dates = getAllDates().ToArray();
        DayOfWeek[] foo = new DayOfWeek[dates.Length];
        for (int max_loop = 0; max_loop < 10000; max_loop ++)
        {
            Stopwatch st1, st2;
            st1 = Stopwatch.StartNew();
            for (int i = 0; i < max_loop; i++)
                for (int j = 0; j < dates.Length; j++)
                    foo[j] = dates[j].DayOfWeek;
            st1.Stop();
            st2 = Stopwatch.StartNew();
            for (int i = 0; i < max_loop; i++)
                for (int j = 0; j < dates.Length; j++)
                    foo[j] = dates[j].dayOfWeekTurbo2();
            st2.Stop();
            Console.WriteLine("{0},{1}", st1.ElapsedTicks, st2.ElapsedTicks);
        }
        Console.ReadLine();
        Console.WriteLine(foo[0]);
    }
