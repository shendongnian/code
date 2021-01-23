        public static void ExecuteSQL(string sqlCommand, Dictionary<string,object> parameters )
        {
            using (SqlConnection dbConn = new SqlConnection(GetConnectionString()))
            {
                dbConn.Open();
                using (SqlCommand dbCommand = new SqlCommand(sqlCommand, dbConn))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            dbCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }
                    dbCommand.ExecuteScalar();
                }
                dbConn.Close();
            }
        }
