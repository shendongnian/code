    static string Get(string chars, int n, int i)
    {
        string ret = "";
        for (int j = 0; j < n; j++) {
            int sizes = (int)Math.Pow(chars.Length, j);
            ret = chars[(i / sizes) % chars.Length] + ret;
        }
        return ret;
    }
