    var parameters = new Dictionary<string, string>();
    var start = new DateTime(2014, 4, 16, 0, 0, 0, DateTimeKind.Utc);
    var end = new DateTime(2014, 6, 19, 0, 0, 0, DateTimeKind.Utc);
    parameters.Add("start", start.ToString());
    parameters.Add("end", end.ToString());
    var t = MobileService.GetTable<TodoItem>();
    var items = t.WithParameters(parameters).ToListAsync().Result;
    Console.WriteLine(string.Join(", ", items));
