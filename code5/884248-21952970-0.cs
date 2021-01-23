    DateTime dt = DateTime.Now;
    Console.WriteLine(dt.Kind);
    dt = DateTime.UtcNow;
    Console.WriteLine(dt.Kind);
    dt = new DateTime(635267088000000000);
    Console.WriteLine(dt.Kind);
