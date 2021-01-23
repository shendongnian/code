    DateTime startAt = new DateTime(2000, 01, 01, 8, 0, 0);
    DateTime endAt = new DateTime(2000, 01, 01, 16, 0, 0);
    
    for (DateTime date = startAt; date < endAt; date = date.AddMinutes(10))
    {
        // create something with this interval
        Console.WriteLine(string.Format("Interval start: {0}, Interval End: {1}", date.ToString("HH:mm"), date.AddMinutes(10).ToString("HH:mm")));
    }
