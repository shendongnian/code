    private static string DoThat(string input)
    {
        var sb = new StringBuilder(input.Length);
        for (int i = 0; i < input.Length; i += 2)
        {
            sb.Append(input, i, 2);
            sb.Append(" ");
        }
        return sb.ToString();
    }
