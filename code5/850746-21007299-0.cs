    private static string RemoveSringStart(string text)
    {
        if (text.Contains("&nbsp;"))
        {
            text = text.Substring(text.IndexOf("&nbsp;") + "&nbsp;".Length);
        }
        return text;
    }
