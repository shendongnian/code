    private static string sqlConnectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
        
        private void DeletingDataBase()
        {
            using (SqlConnection sqlConn = new SqlConnection(sqlConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sqlQuery = "SELECT, INSERT, UPDATE, DELETE";
                    cmd.Connection = sqlConn;
                    cmd.CommandText = sqlQuery;
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch { }
                    finally
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }
