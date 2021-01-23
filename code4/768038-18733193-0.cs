    string sql = "INSERT INTO person (personID) VALUES (@personID)";
    using (MySqlConnection conn = connection())
    using (MySqlCommand cmd = new SqlCommand(sql, conn))
    {
        cmd.Parameters.AddWithValue("@personID", "123345667788");
        conn.Open();
        cmd.ExecuteNonQuery();
    }
