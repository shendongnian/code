    public static string CssClass(this Enum e)
    {
        string result = e.GetType().Name + "-" + e.ToString();
        return result.ToLowerInvariant();
    }
