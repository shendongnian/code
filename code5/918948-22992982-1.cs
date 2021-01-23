    public static bool LegalString(string s)
    {
        string dict = "abcdefghijklmnopqrstuvwxyz0123456789";
        for (int i = 0; i < s.Length; i++)
        {
            if (!dict.Contains(s.Substring(i, 1).ToLower()))
            {
                return false;
            }
        }
        return true;
    }
