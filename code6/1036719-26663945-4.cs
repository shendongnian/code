    // Get all the lines
    var lines = File.ReadAllLines("myfile.txt");
    // Create a list of OnPeriods (see below) which then can be used for statistics
    var onPeriods = new List<OnPeriod>();
    // Make sure we're starting with an 'ON' line, otherwise ignore the first line and take the 2nd
    var start = lines[0].Contains("ON") ? 0 : 1;
    for (int i = start; i < lines.Count(); i = i+2)
    {
        // Parse out datetimes
        var dateOn = DateTime.Parse(lines[i].Split(',')[0]);
        var dateOff = DateTime.Parse(lines[i + 1].Split(',')[0]);
        // Add period
        onPeriods.Add(new OnPeriod{OnDate = dateOn, OffDate = dateOff});
    }
    // Now you can do all kind of magic like
    var secondsOnInTheLastTwoWeeks = onPeriods.Where(p => p.OnDate > DateTime.Now.AddDays(-14)).Select(p => p.OnTime.Seconds).Sum();
