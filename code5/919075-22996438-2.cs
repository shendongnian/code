    string FindPattern(string text)
    {
        if (text == null)
        {
            return null;
        }
    
        return Enumerable
            .Range(1, text.Length / 2)
            .Where(n => text.Length % n == 0)
            .Select(n => text.Substring(0, n))
            .Where(pattern => Enumerable
                .Range(0, text.Length / pattern.Length)
                .SelectMany(i => pattern)
                .SequenceEqual(text))
            .FirstOrDefault();
    }
