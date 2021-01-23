    DateTime dt = DateTime.Now;
    Console.WriteLine(dt);
    //hour
    Console.WriteLine(dt.AddMinutes(60 - dt.Minute));
    //day
    Console.WriteLine(dt.AddHours(24 - dt.Hour));
    //week
    Console.WriteLine(dt.AddDays(7-(int)dt.DayOfWeek));
    //month
    Console.WriteLine(dt.AddDays(DateTime.DaysInMonth(dt.Year,dt.Month)-dt.Day));
