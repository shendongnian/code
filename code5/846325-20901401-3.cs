    public static DataRow[] 
        RegexSearch(this DataTable dt, string column, string pattern)
    {
        var regex = new Regex(pattern);
        return dt.AsEnumerable()
        .Where(row =>
            regex.Match(row.Field<string>(column)).Success)
        .ToArray();
    }
