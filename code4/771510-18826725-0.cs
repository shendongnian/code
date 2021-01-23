       DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
       DateTime lastWeekSaturday = StartOfWeek.AddDays(-1);
       //Console.Write(lastWeekSaturday);
       DateTime currentWeekFriday=  DateTime.Now.AddDays(5 - (int)DateTime.Now.DayOfWeek);
       //Console.Write(currentWeekFriday);
