    public static string Translate(FormattableString text)
    {
        return string.Format(GetTranslation(text.Format),
            text.GetArguments());
    }
    private static string GetTranslation(string text)
    {
        return text; // actually use gettext or whatever
    }
