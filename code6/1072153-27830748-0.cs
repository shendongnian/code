    public static string checkDB()
    {
        string dbName = "";
        using (var conn = new SqlConnection(constring))
        {
            //create command
            SqlCommand command = new SqlCommand();
            //tell the command which connection its using
            command.Connection = conn;
            //inform command that it is a stored procedure and the name of stored procedure
            command.CommandText = "select DB_NAME()";
            command.CommandType = CommandType.Text;
            // try run command and set TicketID to the row inserted into the table.
            try
            {
                conn.Open();
                //run command
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                dbName = reader[0].ToString();
            }
            catch (Exception e)
            {
            }
        }
        return dbName;
    }
