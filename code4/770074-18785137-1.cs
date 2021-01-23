    IEnumerable<string> GetWords(string source)
    {
        var buffer = new StringBuilder(source.Length);
        foreach (var c in source)
        {
            if (c.IsWhiteSpace)
            {
                if(buffer.Length > 0)
                {
                     yield return buffer.ToString();
                     buffer.Clear();
                }
                continue;
            }
            buffer.Append(c);
        }
    }
