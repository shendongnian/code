    public static StringBuilder AppendLineFormat(
        this StringBuilder builder,
        string formatString,
        params object[] args)
    {
        return builder.AppendFormat(formatString, args)
            .AppendLine();
    }
