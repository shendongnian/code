    var drawDates = new[] { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Saturday };
    for (int i = 0; i < 15; i++)
    {
        var from = DateTime.Now.AddDays(i);
        Console.WriteLine("{0} - {1}", from.ToShortDateString(), GetSoonestDrawDate(from, drawDates).ToShortDateString());
    }
