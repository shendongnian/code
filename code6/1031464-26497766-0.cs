    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        SqlCommand comm = new SqlCommand("delete from Trivia", con);
        comm.ExecuteNonQuery();
    }
