    protected void BtnLogin_Click(object sender, EventArgs e)
    {
         try
            {
                string returnURL;
                HttpCookie mycookie;
                //set a role to the user if it's authenticated
                string role = GetRole(txtUserId.Text, txtPassword.Text); 
                if (role != string.Empty)
                {
                    CookieMaker cookie = new CookieMaker();
                    mycookie = cookie.CreateCookie(chkRemember.Checked, 
                                                   txtUserId.Text, role);
                }
                if (cookie != null)
                {
                    Response.Cookies.Add(cookie);
                    Response.Redirect("Main.aspx");
                }
                else
                    lblError.Text = "Invalid username or password.";
            }
            catch (Exception ex) { lblError.Text = ex.Message; }
    }
        public string GetRole(string userID, string pass)
        {
            string role = string.Empty;
                sqlCmd.Connection = sqlCnn;
                sqlCnn.Open();
                sqlCmd.CommandText = @"SELECT COUNT([UserId]) from UserProfile 
                                              WHERE [UserId] = @username AND 
                                                   [Password] = @password";
                sqlCmd.Parameters.AddWithValue("@username", userID);
                sqlCmd.Parameters.AddWithValue("@password", pass);
                if (Convert.ToInt32(sqlCmd.ExecuteScalar()) > 0)
                    role = "Member";
                return role;
        }
