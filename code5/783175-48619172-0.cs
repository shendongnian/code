    public static string ToFixedLength(this string inStr, int length)
    {
        if (inStr.Length == length)
            return inStr;
        if(inStr.Length > length)
            return inStr.Substring(0, length);
        var blanks = Enumerable.Range(1, length - inStr.Length).Select(v => " ").Aggregate((a, b) => $"{a}{b}");
        return $"{inStr}{blanks}";
    }
