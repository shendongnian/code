    public int Hello()
    {
        using(SqlConnection con=new SqlConnection(constring))
        {
            using(SqlCommand cmd=new SqlCommand(Query,con))
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
