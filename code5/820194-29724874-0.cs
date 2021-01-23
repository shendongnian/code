        public static int GetTableCount(string tablename, string connStr = null)
        {
            string stmt = string.Format("SELECT COUNT(*) FROM {0}", tablename);
            if (String.IsNullOrEmpty(connStr))
                connStr = ConnectionString;
            int count = 0;
            try
            {
                using (SqlConnection thisConnection = new SqlConnection(connStr))
                {
                    using (SqlCommand cmdCount = new SqlCommand(stmt, thisConnection))
                    {
                        thisConnection.Open();
                        count = (int)cmdCount.ExecuteScalar();
                    }
                }
                return count;
            }
            catch (Exception ex)
            {
                VDBLogger.LogError(ex);
                return 0;
            }
        }
