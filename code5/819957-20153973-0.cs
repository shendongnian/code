    public static string TruncateString (this string value, int maxChars)
    {
        value = value.trim();
        return value.Length <= maxChars ? value : value.SubString(0, maxChars).Trim() + "...";
    }
