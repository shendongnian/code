    private setBit(int open, int rowID)
    {
        using(MySqlConnection conn = new MySqlConnection(cs)) // Assuming you've already built the connection string.
        {
            conn.Open();
            using(MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE tableName SET columnName = @open WHERE rowID = @id";
                cmd.Parameters.AddWithValue("@open", open);
                cmd.Parameters.AddWithValue("@id", rowID);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
