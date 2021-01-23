    public static string ReplaceAll(string source, string word)
    {
        string pattern = @"\b" + Regex.Escape(word) + @"\b";
        var rx = new Regex(pattern, RegexOptions.IgnoreCase);
        return rx.Replace(source, "<span class='highlight'>$0</span>");
    }
