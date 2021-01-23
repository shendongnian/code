    using (SqlConnection conn = new SqlConnection(connString))
    using (SqlDataAdapter sda = new SqlDataAdapter(sql, conn))
    {
       DataTable dt = new DataTable();
       sda.Fill(dt);
    }
    // do something with `dt`
