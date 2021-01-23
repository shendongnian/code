    public string GetReversedWords(string source)
    {
        var word = new StringBuilder(source.Length);
        var result = new StringBuilder(source.Length);
        var first = true;
        foreach (var c in source.Reverse())
        {
            if (c.IsWhiteSpace)
            {
                first = WriteReverseWord(result, buffer, first);
                buffer.Clear();
                continue;
            }
            buffer.Append(c);
        }
        WriteReverseWord(result, buffer, first);
        return result.ToString();
    }
    private static bool WriteReverseWord(
        StringBuilder output,
        StringBuilder word,
        bool first)
    {
        if (word.Length == 0)
        {
            return first;
        }
        if (!first)
        {
            output.Append(' ');
        }
        for (var i = word.Length -1; i > -1; i--)
        {
            output.Append(word[i]);
        }
        return false;
    }
