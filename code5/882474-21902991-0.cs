    public static string EverythingAfter(this string value, char c)
    {
        if(string.IsNullOrEmpty(value)) return value;
        int idx = value.IndexOf(c);
        return idx < 0 ? "" : value.Substring(idx + 1);
    }
