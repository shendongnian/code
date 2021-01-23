    public static bool IsInt(this string s)
    {
        int x = 0;
        return int.TryParse(s, out x);
    }
