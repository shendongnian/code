    foreach (DateTime date in Enumerable.Range(0, 10)
        .Select(r => DateTime.Now.Date.AddDays(-r)))
    {
        Console.WriteLine(date.Day + " " + date.Month);
    }
