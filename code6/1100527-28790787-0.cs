    public bool ContainsNonAsciiCharacter(string input)
    {
        const int MaxAnsiCode = 127;
        return input.Any(c => c > MaxAnsiCode);
    }
