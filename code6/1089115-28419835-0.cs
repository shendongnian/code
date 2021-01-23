    private void cmdLogin_ServerClick(object sender, System.EventArgs e) {
        
    	lblMessage.Text = "";
    
    	if (String.IsNullOrEmpty(Username) || Username.Length > 15) {
    		lblMessage.Text = "Username is invalid!";
    		return;
    	}
    
    	if (String.IsNullOrEmpty(Password) || Password.Length > 25) {
    		lblMessage.Text = "Password is invalid!";
    		return;
    	}
    
    	if (ValidateUser(TextBoxUserN.Text, TextBoxPassword.Text)) FormsAuthentication.RedirectFromLoginPage(TextBoxUserN.Text,
    	chkPersistCookie.Checked);
    	else lblMessage.Text = "Username and password combination is incorrect!";
    }
    private bool ValidateUser(string username, string password) {
    		string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    		using(SqlConnection con = new SqlConnection(CS)) {
    			string query = "SELECT COUNT(*) FROM customer WHERE UserName = @username AND password = @password";
    			SqlCommand cmd = new SqlCommand(query, con);
    			cmd.Parameters.AddWithValue("@username", username);
    			cmd.Parameters.AddWithValue("@password", password);
    			con.Open();
    			int i = Convert.ToInt32(cmd.ExecuteScalar());
    			//con.Close();
    			if (i > 0) return true //Correct username + password                
    			else return false; //Wrong username + password
    		}
    	}
