    public static string RepeatString(this string input, int count)
    {
        if (!string.IsNullOrEmpty(input))  // <-- Extra !
        {
            return string.Empty;
        }
