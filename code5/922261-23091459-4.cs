    string conStr = @"data source=***; initial catalog=demoDb; integrated security=true";
    SqlConnection con = new SqlConnection(conStr);
    SqlCommand com = new SqlCommand("demoProcedure", con);
    com.CommandType = System.Data.CommandType.StoredProcedure;
    con.Open();
    Console.WriteLine(com.ExecuteScalar());
    con.Close();
