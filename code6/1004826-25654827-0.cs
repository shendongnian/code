    protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        int userId = 0;
        string constr = ConfigurationManager.ConnectionStrings
            ["DatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                cmd.Parameters.AddWithValue("@Password", Login1.Password);
                cmd.Connection = con;
                con.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            switch (userId)
            {
                case -1:
                    Login1.FailureText = "Username and/or password is incorrect.";
                    break;
                case -2:
                    Login1.FailureText = "Account has not been activated.";
                    break;
                default:
                    // RedirectFromLoginPage will take care of creating 
                    // authentication cookie and redirect; you do not need 
                    // to do anything.
                    FormsAuthentication.RedirectFromLoginPage(
                        Login1.UserName, Login1.RememberMeSet);
                    break;
            }
        }
    }
