    using (var connection = new SqlConnection(ConnectionString))
    using (var command = connection.CreateCommand())
    {
        connection.Open();
        command.CommandText = @"insert into Stock([Product]) values (@Product);
                            insert into LandhuisMisje([Product]) values (@Product);
                            insert into TheWineCellar([Product]) values (@Product);"
        command.Parameters.AddWithValue("@Product", AddProductTables.Text);
        command.ExecuteNonQuery()
    }
