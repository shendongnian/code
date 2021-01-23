    using (SqlConnection sqlConn = new SqlConnection())
    {
        conn.Open();
        Sqlmd.Connection = sqlConn;
        SqlDataAdapter da = new SqlDataAdapter(Sqlmd);
       //code goes here...
    }
