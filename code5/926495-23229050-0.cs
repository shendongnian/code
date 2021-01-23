    using(SqlConnection con = new SqlConnection(connectionString))
    using(SqlCommand cmd = new SqlCommand())
    {
       cmd.Connection = con;
       ...
       ...
    }
