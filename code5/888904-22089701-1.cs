    public static class SqlParExtension
    {
        public static void ParseParameters(this SqlCommand cmd)
        {
            var rxPattern = @"(?<=\= |\=)@\w*";
            foreach (System.Text.RegularExpressions.Match item in System.Text.RegularExpressions.Regex.Matches(cmd.CommandText, rxPattern))
            {
                var sqlp = new SqlParameter(item.Value, null);
                cmd.Parameters.Add(sqlp);
            }
        }
    }
