    public static void proof()
            {
                DateTime date = DateTime.MinValue;
                DateTime max_date = DateTime.MaxValue.AddSeconds(-1);
                while (date < max_date)
                {
                    if (date.DayOfWeek != date.dayOfWeekTurbo2())
                    {
                        Console.WriteLine("{0}\t{1}", date.DayOfWeek, date.dayOfWeekTurbo2());
                        Console.ReadLine();
                    }
                    date = date.AddSeconds(1);
                }
            }
