     int current_week=-1;
            foreach (MyClass o in lst3)
            {
                if (current_week > o.WeekOfYear)
                {
                    current_week = o.WeekOfYear;
                    Console.WriteLine("Week: {0} {1} to {2} {3}", o.FirstDayOfWeek.DayOfWeek.ToString() ,o.FirstDayOfWeek, o.LastDayOfWeek.DayOfWeek.ToString(), o.LastDayOfWeek);
                }
                Console.WriteLine("{0} {1}", o.DT.DayOfWeek.ToString(), o.DT);
            }
