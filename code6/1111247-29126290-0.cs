    private static readonly MethodInfo IndexOfMethod =
        typeof(string).GetMethod("IndexOf", new[] { typeof(char) });
    private static readonly Func<string, object, object> MagicCache =
        MagicMethod<string>(IndexOfMethod);
    public static object IndexOf(string s, char c)
    {
        var i = MagicCache;
        return i(s, c);
    }
