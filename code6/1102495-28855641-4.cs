    static bool Conflicting(string table, params Tuple<string, string>[] columnValuePairs)
    {
        DataTable dt = state.Tables[table];
        var remainingPairs = new List<Tuple<string, string>>(columnValuePairs);
        foreach (var row in dt.AsEnumerable())
        {
            int i = 0;
            while (i < remainingPairs.Count)
            {
                Tuple<string, string> columnValuePair = remainingPairs[i];
                if (row.Field<string>(columnValuePair.Item1) == columnValuePair.Item2)
                {
                    remainingPairs.RemoveAt(i);
                    continue;
                }
                i++:
            }
            if (remainingPairs.Count == 0)
            {
                return true;
            }
        }
        return false;
    }
