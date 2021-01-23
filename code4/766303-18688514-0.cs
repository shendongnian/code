    using (SqliteConnection con = new SqliteConnection(connectionString)) 
    {
        con.Open();
        string commandText =  "SELECT * FROM tableName WHERE date=@dt";
        using (SqliteCommand cmd = new SqliteCommand(commandText, con))
        {
            cmd.Parameters.AddWithValue("@dt", yourDateVariable)
            SqliteReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                // Extract your data from the reader here
                .....
            }
        }             
    }
