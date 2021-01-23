    SqlConnection con=new SqlConnection("/*connection string*/");               
    SqlCommand SelectCommand = new SqlCommand("SELECT email FROM table1", con);
    SqlDataReader myreader;
    con.Open();
    myreader = SelectCommand.ExecuteReader();
    String strValue="";
    while (myreader.Read())
     {
        strValue=myreader[0].ToString();
        //strValue=myreader["email"].ToString();
        //strValue=myreader.GetString(0);
     }
    con.Close();
