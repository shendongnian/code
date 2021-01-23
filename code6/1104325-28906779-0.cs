    SqlConnection con = new 
    SqlConnection(WebConfigurationManager.ConnectionStrings["SomeConnectString"].ConnectionString);
    con.Open();
    List<string> lt = new List<string>();
    using (var command = new SqlCommand("Report_FilterSproc", con)
    {
    CommandType = System.Data.CommandType.StoredProcedure
    })
    using (SqlDataReader reader = command.ExecuteReader())
    {
    while (reader.Read())
    {
    lt.add(reader.GetString(1));
    }
    };
    con.Close();
    doStuff(string.Join<string>(";", lt);
