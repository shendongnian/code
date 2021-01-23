    public static string RemoveAngleBracketedContent(string text)
    {
        var builder = new StringBuilder();
        int depth = 0;
        foreach (var character in text)
        {
            if (character == '<')
            {
                depth++;
            }
            else if (character == '>' && depth > 0)
            {
                depth--;
            }
            else if (depth == 0)
            {
                builder.Append(character);
            }
        }
        return builder.ToString();
    }
