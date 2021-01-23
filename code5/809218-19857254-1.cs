    SqlConnection con = new SqlConnection("...");
    string strSQL = "<your_query>";
    SqlCommand cmd = new SqlCommand(strSQL, con);
    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();    
    while (reader.Read())
      int passed = reader["passed"];
    reader.Close();
    con.Close();
