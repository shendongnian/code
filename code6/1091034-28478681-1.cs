    public static bool IsNullOrWhiteSpace(string input)
    {
        if (input == null || input == String.Empty) return true;
        foreach (char c in input)
            if (!Char.IsWhiteSpace(c))
                return false;
        return true;
    }
