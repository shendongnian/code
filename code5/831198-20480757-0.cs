    public static string Replace(string text, string oldValue, string newValue)
    {
        int index = text.IndexOf(oldValue, StringComparison.CurrentCulture);
        if (index >= 0)
            return text.Substring(0, index) + newValue +
                     text.Substring(index + LengthInString(text, oldValue, index));
        else
            return text;
    }
    static int LengthInString(string text, string oldValue, int index)
    {
        for (int length = 1; length < text.Length - index; length++)
            if (string.Equals(text.Substring(index, length), oldValue,
                                                StringComparison.CurrentCulture))
                return length;
        throw new Exception("Oops!");
    }
