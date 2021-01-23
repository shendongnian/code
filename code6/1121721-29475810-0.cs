    static readonly Regex ReplacerRegex = new Regex("[&+%]");
    public static string Replace(Match match)
    {
        // 4-digits hex of the matched char
        return @"\u" + ((int)match.Value[0]).ToString("x4");
    }
    public static string EncodeUTF8(string unescaped)
    {
        return ReplacerRegex.Replace(unescaped, Replace);
    }
