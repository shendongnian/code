    public static string ReplaceComments(string input)
    {
        return Regex.Replace(input, @"(/\*[\w\W]*\*/)|//(.*?)\r?\n",
            s => GenerateWhitespace(s.ToString()));
    }
    public static string GenerateWhitespace(string input)
    {
        var builder = new StringBuilder();
        builder.Append(' ', input.Length);
        return builder.ToString();
    }
