    var loginInfo =
    	// Read the lines in the file, one by one
        File.ReadLines(args[0])
        	// Get a match with appropriate groups for the individual parts
            .Select(l =>
                Regex.Match(l,
                    @"Username:(?<username>[^|]+)\|\|
                      UserId:(?<userid>[^|]+)\|\|
                      Userlogintime:(?<date>\S+)", RegexOptions.IgnorePatternWhitespace))
            // Create a new object with the user name and date
            .Select(m => new {
                Username = m.Groups["username"].Value,
                Date = DateTime.Parse(m.Groups["date"].Value, CultureInfo.GetCultureInfo("en-us"))
            })
            // Group by itself, that is, collapse all identical objects into the same group
            .GroupBy(i => i)
            // Create a new object with user name, date and count
            .Select(g => new {
                Username = g.Key.Username,
                Date = g.Key.Date,
                Count = g.Count()
            });
    foreach (var info in loginInfo) {
        Console.WriteLine("{0} {1} {2}", info.Username, info.Date, info.Count);
    }
