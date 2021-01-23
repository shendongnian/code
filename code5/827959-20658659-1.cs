    retryPolicy.ExecuteAction(() =>
    {
        using (SqlConnection con = new SqlConnection(GetConStr()))
        {
            com.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(com);
            con.OpenWithRetry();
            da.Fill(dt);
        }
    });
