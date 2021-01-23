    SqlConnection myConn = new SqlConnection(myConnection);
    myConn.Open();
    string sql ="YOUR QUERY...";
    SqlConnection myConn = new SqlConnection(myConnection);
    myConn.Open();
    SqlCommand InsertCommand = new SqlCommand(sql,myConn);
    InsertCommand.ExecuteNonQuery();
    myConn.Close();
    
