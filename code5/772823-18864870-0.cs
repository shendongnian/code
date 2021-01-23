    DateTime dt = DateTime.Now;
    Console.WriteLine(dt);
    Console.WriteLine(dt.AddMinutes(60 - dt.Minute));
    Console.WriteLine(dt.AddHours(24 - dt.Hour));
    Console.WriteLine(dt.AddDays(DateTime.DaysInMonth(dt.Year,dt.Month)-dt.Day));
