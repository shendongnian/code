    var data = new List<DateTime>()
    {
        DateTime.Today,
        DateTime.Today.AddMinutes(1.5),
        DateTime.Today.AddMinutes(2.5),
        DateTime.Today.AddMinutes(5),
    };
    var query = LoneDates(data, TimeSpan.FromMinutes(2));
    Console.WriteLine(string.Join("\n", query));
