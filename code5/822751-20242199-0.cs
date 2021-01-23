    SqlConnection conn = new SqlConnection("YourConnectionString");
    SqlCommand cmd = new SqlCommand(@"select * from Users where role='member' and
    SUBSTRinG(lname, 1, 1) = @query ORDER BY lname ASC");
    cmd.Parameters.AddWithValue("@query", querystring);
    
    DataTable resultTable = new DataTable();
    
    try
    {
      SqlDataAdapter da = new SqlDataAdapter(cmd);
      da.Fill(resultTable);
    } finally {
      if (conn.State != ConnectionState.Closed) conn.Close();
    }
    
    Console.WriteLine(String.Format("Matched {0} Rows.", resultTable.Rows.Count));
