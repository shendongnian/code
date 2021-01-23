    static string Get(string chars, int n, int i)
    {
        string ret = "";
        int sizes = 1;
        for (int j = 0; j < n; j++) {
            ret = chars[(i / sizes) % chars.Length] + ret;
            sizes *= chars.Length;
        }
        return ret;
    }
