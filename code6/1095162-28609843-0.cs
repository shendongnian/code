    DateTime date = new DateTime(2015, 02, 19, 0, 0, 0);
    Console.WriteLine(date.ToString("hh:mm tt", CultureInfo.InvariantCulture));
    // Displays 12:00 AM
    Console.WriteLine(date.ToString("HH:mm tt", CultureInfo.InvariantCulture));
    // Displays 00:00 AM
