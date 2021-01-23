    using(SqlConnection connection = new SqlConnection("Connection string"))
    {
        connection.Open();
        using(SqlCommand command = new SqlCommand("SELECT * FROM TableName", connection))
        {
            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
                // read and process data somehow (possible source of exceptions)
            }
            catch(Exception ex)
            {
                // handle exception somehow
            }
            finally
            {
               reader.Close();
            }
        } 
    }
