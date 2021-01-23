    public static bool ContainsAlpha(string s)
    {
        if (s == null) return false;
        for (int i = 0; i < s.Length; i++)
            if (Char.IsLetter(s, i))
                return true;
        return false;
    }
