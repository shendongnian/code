    static string HazNoName(Match match)
    {
        return char.ConvertFromUtf32(Int32.Parse(match.Groups[1].Value,
             System.Globalization.NumberStyles.HexNumber));
    }
    //...
    json = regex.Replace(json, new MatchEvaluator(HazNoName));
