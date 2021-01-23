    static bool Conflicting(string table, params Tuple<string, string>[] columnValuePairs)
    {
        DataTable dt = state.Tables[table];
        return dt.AsEnumerable().Any(
            row => columnValuePairs.Any(p => row.Field<string>(p.Item1) == p.Item2));
    }
