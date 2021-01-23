    var dt1 = new DateTime(2015, 1, 2, 14, 2, 47);
    var dt2 = new DateTime(2014, 12, 15, 16, 14, 50);
    var ts = dt1 - dt2;
    Console.WriteLine(ts.Days); // 17
    Console.WriteLine(ts.Hours); // 21
    Console.WriteLine(ts.Minutes); // 47
    Console.WriteLine(ts.Seconds); // 57
