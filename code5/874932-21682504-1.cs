    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        DAL = new DataAccessLayer();
        conObj = DAL.openConnection();
        string query = "SELECT * FROM tblUser WHERE UEmail = '"+Login1.UserName+"'";
        string failureText=string.empty;
    
        SqlDataReader SQLDR = DAL.ExecuteQueryReturnValue(query);
    
        if (SQLDR.Read())
        {
            if (SQLDR["UPassword"].ToString() == Login1.Password.ToString())
            {
    
                Session["userName"] = SQLDR["UEmail"].ToString();
                e.Authenticated = true;
            }
            else {
                // Change the 'FailureText' to "password is incorrect"
                failureText="password is incorrect";
                e.Authenticated = false;
            }
    
        }
        else
        {
            // Here I want to change the 'FailureText' to "User does not exists"
            failureText="User does not exists";
            e.Authenticated = false;
        }
    
        if(!e.Authenticated)
        {
            // Use failureText where you need it
            FailureText.Text=string.Format("<h1>{0}</h1>", failureText);
        }
        else
        {
            FailureText.Text=string.empty;
        }
       }
