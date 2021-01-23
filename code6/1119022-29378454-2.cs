    public static int FindDistance(string s1, string s2, bool forceLowerCase = false)
    {
        if (String.IsNullOrEmpty(s1) || s1.Length == 0)
            return String.IsNullOrEmpty(s2) ? s2.Length : 0;
        if (String.IsNullOrEmpty(s2) || s2.Length == 0)
            return String.IsNullOrEmpty(s1) ? s1.Length : 0;
        // not in Levenshtein but I need it.
        if (forceLowerCase)
        {
            s1 = s1.ToLowerInvariant();
            s2 = s2.ToLowerInvariant();
        }
        int s1Len = s1.Length;
        int s2Len = s2.Length;
        int[,] d = new int[s1Len + 1, s2Len + 1];
        for (int i = 0; i <= s1Len; i++)
            d[i, 0] = i;
        for (int j = 0; j <= s2Len; j++)
            d[0, j] = j;
        for (int i = 1; i <= s1Len; i++)
        {
            for (int j = 1; j <= s2Len; j++)
            {
                int cost = Convert.ToInt32(s1[i - 1] != s2[j - 1]);
                int min = Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1);
                d[i, j] = Math.Min(min, d[i - 1, j - 1] + cost);
            }
        }
        return d[s1Len, s2Len];
    }
