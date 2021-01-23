    System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
    DayOfWeek firstDayOfWeek = ci.DateTimeFormat.FirstDayOfWeek;
    int offset = firstDayOfWeek - DateTime.Now.DayOfWeek;
    DayOfWeek lastDayOfWeek = DateTime.Now.AddDays(offset).AddDays(6).DayOfWeek;
    
    DateTime input = DateTime.Now.AddDays(1);
    DateTime startOfWeek = DateTime.Today;
    while (startOfWeek.DayOfWeek != firstDayOfWeek)
        startOfWeek = startOfWeek.AddDays(-1);
    DateTime endOfWeek = DateTime.Now;
    while (endOfWeek.DayOfWeek != lastDayOfWeek)
        endOfWeek = endOfWeek.AddDays(1);
    
    Console.WriteLine("Week starts: " + startOfWeek);
    Console.WriteLine("Week ends: " + endOfWeek);
    Console.WriteLine("Input was: " + input);
    
    Console.Write("Is input this week? ");
    bool thisWeek = input >= startOfWeek && input <= endOfWeek;
    Console.WriteLine(thisWeek);
