    public static IEnumerable<string> SplitCSV(string csvString)
    {
        var sb = new StringBuilder();
        bool quoted = false;
        foreach (char c in csvString)
        {
            if (quoted)
            {
                if (c == '"')
                    quoted = false;
                else
                    sb.Append(c);
            }
            else
            {
                if (c == '"')
                {
                    quoted = true;
                }
                else if (c == ',')
                {
                    yield return sb.ToString();
                    sb.Length = 0;
                }
                else
                {
                    sb.Append(c);
                }
            }
        }
        if (quoted)
            throw new ArgumentException("csvString", "Unterminated quotation mark.");
        yield return sb.ToString();
    }
