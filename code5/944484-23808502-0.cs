    private static string NumberFromString(string input)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]))
                sb.Append(input[i]);
        }
        return sb.ToString();
    }
