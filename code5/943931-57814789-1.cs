    string x = "2019-08-20 13:35:04.27";
    DateTime d;
    bool result = DateTime.TryParseExact(x, "yyyy-MM-dd HH:mm:ss.fff", 
    System.Globalization.CultureInfo.InvariantCulture, 
    System.Globalization.DateTimeStyles.None, out d);
    Console.WriteLine(result);
