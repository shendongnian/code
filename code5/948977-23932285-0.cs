    var startHour = new DateTime(2000, 01, 01, 08, 00, 00);
    var endHour = new DateTime(2000, 01, 01, 22, 00, 00);
    var step = TimeSpan.FromMinutes(15);
    for (var time = startHour; time <= endHour; time += step)
    {
        Console.WriteLine(time.ToString("HH:mm"));
    }
