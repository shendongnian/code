        DateTime dt = new DateTime(2015, 3, 29, 2, 59, 0, DateTimeKind.Local);
        DateTime dt2 = dt.ToUniversalTime();
        Console.WriteLine(dt.ToString());
        Console.WriteLine(dt.AddMinutes(1).ToString());
        Console.WriteLine(dt2.AddMinutes(1).ToLocalTime().ToString());
