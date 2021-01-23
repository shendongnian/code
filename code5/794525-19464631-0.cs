    var loginInfo = File.ReadLines(args[0])
                        .Select(l => Regex.Match(l, @"Username:(?<username>[^|]+)\|\|UserId:(?<userid>[^|]+)\|\|Userlogintime:(?<date>\S+)"))
                        .Select(m => new {
                            Username = m.Groups["username"].Value,
                            Date = DateTime.Parse(m.Groups["date"].Value, CultureInfo.GetCultureInfo("en-us"))
                        })
                        .GroupBy(i => i)
                        .Select(g => new { Username = g.Key.Username, Date = g.Key.Date, Count = g.Count() });
    foreach (var info in loginInfo) {
        Console.WriteLine("{0} {1} {2}", info.Username, info.Date, info.Count);
    }
