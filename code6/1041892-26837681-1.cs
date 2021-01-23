    using (SqlConnection conn = DataConnection.Con)
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            //use the command here
        }
    }
