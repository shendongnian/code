    public bool HasRegexMatchInOrder(string input, params string[] patterns)
    {
        foreach (var pattern in patterns)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }
        }
        return false;
    }
    string input = "hello world";
    bool hasAMatch = HasRegexMatchInOrder(input, "hello world", "hello", ...);
