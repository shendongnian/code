    List<string> validStrings = new List<string>
    {
        "02:00#03:00",
        "02:00,04:00,06:00#03:00",
        "02:00#03:00,06:00"
    };
    Console.WriteLine("VALID Strings");
    Console.WriteLine("============================");
    foreach (var item in validStrings)
    {
        Console.WriteLine("Result: {0}, string: {1}", CheckValid(item), item);
    }
    Console.WriteLine("INVALID strings");
    Console.WriteLine("============================");
    List<string> invalidStrings = new List<string>
    {
        "02:00,#03:00",
         "02:00#03:00,",
    };
    foreach (var item in invalidStrings)
    {
        Console.WriteLine("Result: {0}, string: {1}", CheckValid(item), item);
    }
