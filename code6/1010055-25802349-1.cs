    using(var con = new SqlConection(WebConfigurationManager.ConnectionStrings["insertBulkConnectionString"].ConnectionString))
    using(var da = new SqlDataAdapter("SELECT * FROM Table ORDER BY Column", con))
    {
        da.Fill(dt);  // you don't need to add the columns or to open the connection
    }
