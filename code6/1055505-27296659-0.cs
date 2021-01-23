    public static string ToUpperUntilSecondHyphen(string text)
    {
        int index = text.IndexOf('-', text.IndexOf('-') + 1);
        return text.Substring(0, index).ToUpper() + text.Substring(index);
    }
