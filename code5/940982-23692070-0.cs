    var input = DateTime.Now.AddDays(1); // may 16 2014
    DateTime StartOfWeek = DateTime.Today;
    while (StartOfWeek.DayOfWeek != DayOfWeek.Sunday)
           StartOfWeek = StartOfWeek.AddDays(-1);
    DateTime EndOfWeek = DateTime.Today;
    while (EndOfWeek.DayOfWeek != DayOfWeek.Saturday)
           EndOfWeek = EndOfWeek.AddDays(1);
    Console.WriteLine("Week starts: " + StartOfWeek);
    Console.WriteLine("Week ends: " + EndOfWeek);
    Console.WriteLine("Input was: " + input);
    Console.Write("Is input this week? ");
    var thisWeek = input >= StartOfWeek && input <= EndOfWeek;
    Console.WriteLine(thisWeek);
