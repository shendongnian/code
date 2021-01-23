    private static bool createDB(SqlConnection dbConn, string dbName)
    {
        string sqlString = "CREATE DATABASE " + dbname;
        using (dbConn)
        {
            using (SqlCommand cmd = new SqlCommand(sqlString, dbConn))
            {
                cmd.CommandType = CommandType.Text;
              
                dbConn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se creo la DB");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se creo la DB");
                    return false;
                }
                finally
                {
                    //dbConn.Close();
                }
            }
        }
    }
