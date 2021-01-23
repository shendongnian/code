    private static string RemoveStringStart(string text)
    {
        var splitAt = "&nbsp;";
        if (text.Contains(splitAt))
        {
            text = text.Substring(text.IndexOf(splitAt) + splitAt.Length);
        }
        return text;
    }
