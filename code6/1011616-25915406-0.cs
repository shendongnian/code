    using (VistaDBConnection connection = new VistaDBConnection())
    {
        connection.ConnectionString = @"Data Source=C:\mydatabase.vdb5";
        connection.Open();
    
        using (VistaDBCommand command = new VistaDBCommand())
        {
            int Age = 21;
    
            command.Connection = connection;
            command.CommandText = "INSERT INTO MyTable (MyColumn) VALUES (@age)";
            command.Parameters.Add("@age", Age);
            command.ExecuteNonQuery();
        }
    }
