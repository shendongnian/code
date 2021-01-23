    using (SqlConnection con = new SqlConnection(constring))
    {
       using (SqlCommand cmd = new SqlCommand("your query here", con))
       {
           con.Open(); 
           cmd.ExecuteNonQuery();
       }
    }
