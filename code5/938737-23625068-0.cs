    //Wrong
    SqlConnection con = new SqlConnection("");
    
    //Right
    string szConnectStr = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;
    Password=myPassword;";
    SqlConnection con = new SqlConnection(szConnectStr);
    con.Open
    {
       //code here
    }
    con.Close();
