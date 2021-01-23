    static string[] SplitWords(string lines)
    {
        return Regex.Split(lines, @"[^-'a-zA-Z]")
                    .Where(s => !s.All(Char.IsWhiteSpace))
                    .ToArray();
    }
