    using (MySqlConnection conn = new MySqlConnection("connection text here"))
    {
        conn.Open();
        things = "INSERT INTO vikoba.members(id_no , names_) VALUES (@id, @name)";
        using (MySqlCommand cmd = new MySqlCommand(things, con))
        {
    /* body of code here */
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        
        conn.Close();
    }
