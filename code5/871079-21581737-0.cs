    public static string Reverse(this string source)
    {
        var chars = source.ToCharArray();
        Array.Reverse(chars);
        return new String(chars);
    }
