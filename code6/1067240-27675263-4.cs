    string logLine = "Dec 25 14:11:03 Hello world!";
    // Your new pattern:
    string pattern = @"([a-z]{3} \d{2} \d{2}:\d{2}:\d{2})";
    Match match = Regex.Match(logLine, pattern, RegexOptions.IgnoreCase);
    if (match.Success)
    {
        string dateFormat = "MMM dd HH:mm:ss";
        string dateString = match.Groups[1].Value;
        DateTime date = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
        long ticks = date.Ticks;
    }
