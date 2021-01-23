    public decimal ReadMilliseconds()
    {
        var lines = File.ReadLines(@"\path\to\file");
        decimal totalMilliseconds = 0;
        foreach (string line in lines)
        {
            var match = Regex.Match(line, @"(?<ms>\d*\.?\d*)\s*mili");
            if (!match.Success) continue;
            decimal value = decimal.Parse(match.Groups["ms"].Value, new CultureInfo("en-US"));
            totalMilliseconds += value;
        }
        return totalMilliseconds;
    }
