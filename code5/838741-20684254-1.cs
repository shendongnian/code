    public static string Truncate(string input, int length)
    {
        if (input.Length <= length)
        {
            return input;
        }
        else
        {
            return input.Substring(0, length) + "...";
        }
    }
