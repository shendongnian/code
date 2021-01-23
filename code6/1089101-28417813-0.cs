    public static bool IsServerConnected(string connectionString)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        return true;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                    finally
                    {
                        try
                         {
                             connection.Close();
                         }
                         catch (Exception ex)
                         {
                         }
                    }
                }
            }
