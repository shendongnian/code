    protected void Some_Action(object sender, EventArgs e)
    {
        using(SqlConnection con = new SqlConnection(@"connectionString"))
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("Query Here", con))
            {
                // Do stuff with the command here like setting Parameters.
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    // Do stuff with the reader here
                }
            }
        }
    }
