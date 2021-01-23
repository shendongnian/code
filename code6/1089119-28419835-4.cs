        protected void cmdLogin_ServerClick(object sender, System.EventArgs e) {
    	try {
    		lblMessage.Text = "";
    
    		if (String.IsNullOrEmpty(TextBoxUserN.Text) || TextBoxUserN.Text.Length > 15) {
    			lblMessage.Text = "Username is invalid!";
    			return;
    		}
    
    		if (String.IsNullOrEmpty(TextBoxPassword.Text) || TextBoxPassword.Text.Length > 25) {
    			lblMessage.Text = "Password is invalid!";
    			return;
    		}
    
    		if (ValidateUser(TextBoxUserN.Text, TextBoxPassword.Text)) FormsAuthentication.RedirectFromLoginPage(TextBoxUserN.Text,
    		chkPersistCookie.Checked);
    		else lblMessage.Text = "Username and password combination is incorrect!";
    	} catch (Exception ex) {
    		lblMessage.Text = "An error has occurred, please try again later!";
    		System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
    	}
    }
    
    private bool ValidateUser(string username, string password) {
    	string CS = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    	using(SqlConnection con = new SqlConnection(CS)) {
    		string query = "SELECT COUNT(*) FROM customer WHERE UserName = @username AND password = @password COLLATE SQL_Latin1_General_CP1_CS_AS"; //password is case SeNsiTive
    		SqlCommand cmd = new SqlCommand(query, con);
    		cmd.Parameters.AddWithValue("@username", username);
    		cmd.Parameters.AddWithValue("@password", password);
    		con.Open();
    		int i = Convert.ToInt32(cmd.ExecuteScalar());
    		//con.Close();
    		if (i == 1) return true //Correct username + password                
    		else return false; //Wrong username + password
    	}
    }
