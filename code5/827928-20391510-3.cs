    public static bool CheckHTMLForText(string html)
    {
        var stripped = StringHelpers.StripTagsWithContent(html, "script", "style");
        stripped = StringHelpers.StripTagsRegex(stripped);
        return string.IsNullOrWhiteSpace(stripped);
    }
