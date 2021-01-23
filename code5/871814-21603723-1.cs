    using (var conn = new MySqlConnection(ConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "select * from `order` where Column1=@combo AND Column2=@txt";
        cmd.Parameters.AddWithValue("@combo", combo); // set the combo parameter
        cmd.Parameters.AddWithValue("@txt", txt); // set the txt parameter
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                //You can read values here..
            }
        }
    }
