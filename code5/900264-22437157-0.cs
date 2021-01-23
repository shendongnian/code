    public static string F(string s)
    {
       if (s.Length >= 2)
            return new string(new[] { s[s.Length - 1], s[0] });
        else
            return s;
    }
