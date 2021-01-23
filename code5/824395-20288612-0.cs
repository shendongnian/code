    DateTime dt1 = new DateTime(2014, 1, 1);
    DateTime dt2 = new DateTime(2014, 10, 15);
    DateTime start = new DateTime(2014, 1, 3);
    while (start < dt2)
    {
        Console.WriteLine(start);
        start = start.AddDays(3);
    }
