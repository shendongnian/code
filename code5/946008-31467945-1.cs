    public static bool IsControl2(char c)
    {
        return c <= 31 || (c >= 127 && c <= 159);
    }
    public static bool IsControl3(char c)
    {
        return c <= 159 && (c <= 31 || c >= 127);
    }
