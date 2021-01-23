    public static string ExpandCode(string s)
    {
        string alfa = string.Empty;
        string num = string.Empty;
        foreach (char t in s)
            if (t < 'A')
                num += t;
            else
                alfa += t;
        for (int i = 0; i < 15 - s.Length; i++)
            alfa += '0';
        return alfa + num;
    }
