    DateTime date;
    if (DateTime.TryParseExact("06:45 AM", new[] {"hh:mm tt"}, null, DateTimeStyles.None, out date))
    {
        Console.WriteLine(date);
        Console.WriteLine(date.TimeOfDay);
    }
