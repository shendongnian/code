    public static string ParseValue(string sourceStr)
    {
        string pattern = @"\(\d{2}\) \d \d{7} \d{9} \d";
        return System.Text.RegularExpressions.Regex.Match(sourceStr, pattern).Value;
    }
