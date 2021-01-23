    private class User
    {
        public int UserID {get;set;}
        public string Role {get;set;}
        public string UserName {get;set;}
    }
    private bool ValidationFunction(string username, string pwd, out User)
        {
            bool boolReturnValue = false;
    
            string s = "correct connection string";
            SqlConnection con = new SqlConnection(s);
            con.Open();
            string sqlUserName;
            sqlUserName = "SELECT UserName,Password,UserID,Role FROM Users WHERE UserName =@usr AND Password=@pwd";
            SqlCommand cmd = new SqlCommand(sqlUserName, con);
            cmd.Parameters.Add(new SqlParameter("usr", username));
            cmd.Parameters.Add(new SqlParameter("pwd", pwd));
    
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                boolReturnValue = true;
                User = new User(){UserName = username, UserID=reader.GetInt32(2), Role=reader.GetString(3)};
            }
            else
            {
                Session["UserName"] = "";
                boolReturnValue = false;
            }
            return boolReturnValue;
        }
