    private static string[] SplitSpecial(string s)
    {
        List<string> tmp = new List<string>();
        int lastindex = 0;
        for (int i = 1; i < s.Length; i++)
            if (Char.IsUpper(s[i]) && (Char.IsLower(s[i - 1]) || (i < s.Length - 1 && Char.IsLower(s[i + 1]))))
            {
                if (i > lastindex)
                    tmp.Add(s.Substring(lastindex, i - lastindex));
                lastindex = i;
            }
        tmp.Add(s.Substring(lastindex, s.Length - lastindex));
        return tmp.ToArray();
    }
