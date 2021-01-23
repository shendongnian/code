    private int FindIndexOf(List<string> list, params string[] args)
    {
        string pattern = args.Aggregate(new StringBuilder(), 
            (sb, a) => sb.Append("(?=.*").Append(Regex.Escape(a)).Append(")")
        ).ToString();
        Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase);
        return list.FindIndex(s => regEx.IsMatch(s));
    }
