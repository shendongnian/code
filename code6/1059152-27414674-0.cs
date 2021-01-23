    using(SqlConnection connection = new SqlConnection(strSQLConnectionString)
    {
        using(SqlCommand updateCommand = new SqlCommand(strUpdateCommand, connection)
        {
            //Your code goes here.
        }
    }
