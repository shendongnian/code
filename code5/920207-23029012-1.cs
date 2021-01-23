    public void TrimString(string text)
    {
        // This changes the value of the *parameter*, but doesn't affect the original
        // *object* (strings are immutable). The caller won't see any effect!
        text = text.Trim();
    }
