    public static class SqlParExtention
    {
        public static void ParseParameters(this SqlCommand cmd)
        {
            foreach (System.Text.RegularExpressions.Match item in System.Text.RegularExpressions.Regex.Matches(cmd.CommandText, @"(?<=\= )@\w*"))
            {
                SqlParameter sqlp = new SqlParameter(item.Value, null);
                cmd.Parameters.Add(sqlp);
            }
        }
    }
