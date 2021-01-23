    string cs = @"Data Source=.\SQLEXPRESS;
               AttachDbFilename=|DataDirectory|\Stock.mdf; |
               Integrated Security=True;
               Connect Timeout=30;
               User Instance=True";
    using (SqlConnection con = new SqlConnection(cs))
    using (SqlCommand cmd = new SqlCommand("UPDATE table SET Quantity=@q WHERE Id=@Id", con))
    {
        cmd.Parameters.AddWithValue("@q", newQuanity);
        cmd.Parameters.AddWithValue("@Id", GivenId);
        con.Open();
        cmd.ExecuteNonQuery();
    }
