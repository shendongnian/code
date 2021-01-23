        static SqlConnection _conn;
        static string _connStr = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["primaryConnStr"]].ToString();
        static SqlCommand _cmd;
        static SqlDataAdapter _dataAdapter = new SqlDataAdapter();
        public static DataTable GetTable(string sProcName, SqlParameter[] sqlParams)
        {
            using (_conn = new SqlConnection(_connStr))
            {
                _cmd = new SqlCommand(sProcName, _conn);
                _conn.Open();
                _cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParams != null)
                {
                    _cmd.Parameters.AddRange(sqlParams);
                }
                _dataAdapter = new SqlDataAdapter(_cmd);
                var results = new DataTable();
                _dataAdapter.Fill(results);
                _conn.Close();
                return results;
            }
        }
