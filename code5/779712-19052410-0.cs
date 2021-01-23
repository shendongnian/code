    string Data = @"[{
        ""created_at"": ""Fri Sep 27 02:00:08 +0000 2013"",
        ""id"": 1
    },
    {
        ""created_at"": ""Sat Sep 28 02:00:08 +0000 2013"",
        ""id"": 1
    }]";
    IEnumerable<dynamic> d = (dynamic)JsonConvert.DeserializeObject(Data);
    var dates = d.Select(x => DateTime.ParseExact(x.created_at.ToString(),
        "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture))
        .Cast<DateTime>().ToList();
    var maxDate = dates.Max();
    var minDate = dates.Min();
