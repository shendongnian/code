    using (OdbcConnection connection = new OdbcConnection(connectionString))
    {
        string sp = "{call spFoo (?, ?)}";
        using (OdbcCommand command = new OdbcCommand(sp, connection))
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            //the order here is important, the names are not!
            command.Parameters.Add("@name", OdbcType.VarChar).Value = "test name";
            command.Parameters.Add("@phone", OdbcType.VarChar).Value = "test phone";
                    
            Console.WriteLine(command.ExecuteNonQuery().ToString());
        }
    }
