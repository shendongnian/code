    public static string ToMySpecialAsciiString(string input)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in input)
            result.AppendFormat("{0:x2} ", c + 1);
        return result.ToString();
    }
