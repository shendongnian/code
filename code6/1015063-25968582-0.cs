    string userName = userNameBox.Text;
    string passWord = passWordBox.Text;
    string connStr = ConfigurationManager.ConnectionStrings["lagerConn"].ConnectionString;
    connStr = connStr.Replace("User ID=;", "User ID=" + userName + ";");
    connStr = connStr.Replace("Password=", "Password='" + passWord + "'");
    bool loginFail = false;
    try{
        using (SqlConnection Conn = new SqlConnection(connStr){
           loginFail true;
        }
    }
    catch (SqlConnection sqlEx){
       //already false
    }
