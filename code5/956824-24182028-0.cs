    internal static class SqlCommandHelper
    {
        internal static string ExecuteBatchNonQuery(this SqlCommand cmd, string sql)
        {
            var sb = new StringBuilder(); 
            SqlConnection conn = cmd.Connection;
            conn.Open();
            conn.InfoMessage += (sender, e) => { sb.AppendLine(e.Message); };
            string sqlBatch = string.Empty;
            sql += "\nGO"; // make sure last batch is executed.
            sb.Clear();
            try
            {
                foreach (string line in sql.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.ToUpperInvariant().Trim() == "GO")
                    {
                        cmd.CommandText = sqlBatch;
                        cmd.ExecuteNonQuery();
                        sqlBatch = string.Empty;
                    }
                    else
                    {
                        sqlBatch += line + "\n";
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return sb.ToString();
        }
    }
