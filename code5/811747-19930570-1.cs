    public static string ExpandCode4(string s)
    {
        char[] res = new char[15];
        int ind = 0;
        for (int i = 0; i < s.Length && s[i] >= 'A'; i++)
            res[ind++] = s[i];
        int tillDigit = ind;
        for (int i = 0; i < 15 - s.Length; i++)
            res[ind++] = '0';
        for (int i = 0; i < s.Length - tillDigit; i++)
            res[ind++] = s[tillDigit + i];
        return new string(res);
    }
