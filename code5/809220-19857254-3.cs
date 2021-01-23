    SqlConnection con = new SqlConnection("...");
    string strSQL = "<your_query>";
    SqlCommand cmd = new SqlCommand(strSQL, con);
    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();   
    int passed, failed; 
    while (reader.Read())
    {
        passed = (int) reader["passed"];
        failed = (int) reader["failed"];
    }
    reader.Close();
    con.Close();
    //do something with your variables ....
