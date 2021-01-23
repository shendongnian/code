    public bool IsCorrectString(string val)
    {
        foreach (char c in val)
        {
            if (!char.IsWhiteSpace(c) && !char.IsLetter(c))
                return false;
        }
        return true;
    }
