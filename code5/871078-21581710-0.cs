    public static string ReverseSingleString(this string value)
    {
        StringBuilder sb = new StringBuilder(value.Length);
        for(int i = value.Length - 1; i >= 0; i--)
            sb.Append(value[i]);
        return sb.ToString();
    }
