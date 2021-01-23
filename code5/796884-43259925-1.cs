    public static TimeSpan ParseHuman(string dateTime)
    {
        TimeSpan ts = TimeSpan.Zero;
        string currentString = ""; string currentNumber = "";
        foreach (char ch in dateTime+' ')
            {
                currentString += ch;
                if (Regex.IsMatch(currentString, @"^(days(\d|\s)|day(\d|\s)|d(\d|\s))", RegexOptions.IgnoreCase)) { ts = ts.Add(TimeSpan.FromDays(int.Parse(currentNumber))); currentString = ""; currentNumber = ""; }
                if (Regex.IsMatch(currentString, @"^(hours(\d|\s)|hour(\d|\s)|h(\d|\s))", RegexOptions.IgnoreCase)) { ts = ts.Add(TimeSpan.FromHours(int.Parse(currentNumber))); currentString = ""; currentNumber = ""; }
                if (Regex.IsMatch(currentString, @"^(ms(\d|\s))", RegexOptions.IgnoreCase)) { ts = ts.Add(TimeSpan.FromMilliseconds(int.Parse(currentNumber))); currentString = ""; currentNumber = ""; }
                if (Regex.IsMatch(currentString, @"^(mins(\d|\s)|min(\d|\s)|m(\d|\s))", RegexOptions.IgnoreCase)) { ts = ts.Add(TimeSpan.FromMinutes(int.Parse(currentNumber))); currentString = ""; currentNumber = ""; }
                if (Regex.IsMatch(currentString, @"^(secs(\d|\s)|sec(\d|\s)|s(\d|\s))", RegexOptions.IgnoreCase)) { ts = ts.Add(TimeSpan.FromSeconds(int.Parse(currentNumber))); currentString = ""; currentNumber = ""; }
                if (Regex.IsMatch(ch.ToString(), @"\d")) { currentNumber += ch; currentString = ""; }
            }
        return ts;
    }
