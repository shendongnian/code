    public static string TakeTwoFromPosition(string str, int n)
    {
        if (str.Length <= n + 2)
        {
            return str.Substring(n, 2);
        }
    
        return str.Substring(0, 2);
    }
