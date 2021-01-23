    public static bool FPContains(this string a, string b)
    {
        if (a == null || b == null)
            return false;
        return b.Contains(a);
    }
