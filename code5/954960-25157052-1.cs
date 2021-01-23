    public static bool CheckUserAdminOrNot(your arguments)
    {
        string currentUser = HttpContext.Current.Request.LogonUserIdentity.Name;
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string[] words = currentUser.Split('\\');
        currentUser = words[1];
        bool appuser = IsApplicationUser(currentUser);
        if (appuser)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(str))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                string strquery = "select Role_Cd from User_Role where AppCode='PM' and UserID = '" + currentUser + "'";
                SqlCommand cmd = new SqlCommand(strquery, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
    
            if(user is not Admin)
                
                return string that you want....
            }
        }
    }
