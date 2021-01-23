    using (SqlConnection ThisConnection = new SqlConnection(ConnectionString))
    using (SqlCommand sqlCmd = new SqlCommand())
    {
        sqlCmd.Connection = ThisConnection;
        // DB stuff here
    }
