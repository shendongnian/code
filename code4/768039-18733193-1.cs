    string sql = "INSERT INTO person (personID) VALUES (@personID)";
    using (MySqlConnection conn = connection())
    using (MySqlCommand cmd = new SqlCommand(sql, conn))
    {
        cmd.Parameters.AddWithValue("@personID", personID);
        conn.Open();
        cmd.ExecuteNonQuery();
    }
