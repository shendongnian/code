    string Reverse(string s)
    {
        char[] c = new char[s.Length];
        for (int i = s.Length-1, j = 0; i >=0 ; i--, j++)
        {
            c[j] = s[i];
        }
        return new string(c);
    }
