    public static String replaceDashInQuotes(this string source, String newValue)
    {
        StringBuilder sb = new StringBuilder();
        bool inquote = false;
        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == '\"')
                inquote = !inquote;
            if (source[i] == '-' && inquote)
                sb.Append(newValue);
            else
                sb.Append(source[i]);
        }
        return sb.ToString();
    }
