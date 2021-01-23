    public static string ToUpperUntilSecondOccurenceOfChar(string text, char c)
    {
        int index = text.IndexOf(c, text.IndexOf(c) + 1);
        return text.Substring(0, index).ToUpper() + text.Substring(index);
    }
