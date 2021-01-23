select title,[file path],[Upload Date] from [Media] where ID=@id
    using (var conn = new SqlConnection(SomeConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "select title,[file path],[Upload Date] from [Media] where ID=@id";
        cmd.Parameters.AddWithValue("@id", idval); // set the id parameter
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read()) // you don't need while loop
            {
                pathTextBox.Text = reader.GetString(reader.GetOrdinal("[file path]"))
            }
        }
    }
