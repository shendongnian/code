        string s = "PT10H130M10S";
        PeriodPattern pattern = PeriodPattern.RoundtripPattern;
        ParseResult<Period> result = pattern.Parse(s);
        if (result.Success)
        {
            Period p = result.Value;
            Debug.WriteLine(p.Hours);   // 10
            Debug.WriteLine(p.Minutes); // 130
            Debug.WriteLine(p.Seconds); // 10
        }
