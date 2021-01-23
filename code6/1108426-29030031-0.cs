    string similar = null;
    for (int i = 0; i < s1.Length; i++)
    {
        string s = s1.Substring(0, i + 1);
         if (s2.Contains(s))
         {
             similar = s;
         }
    }
    char[] result = similar.ToCharArray();
