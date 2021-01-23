    protected void loginbtn_Click(object sender, EventArgs e)
    {
    	string conString = WindowsApplication1.Properties.Settings.Default.ConnectionString;
    	using (SqlConnection con = new SqlConnection(conString))
    	{
    	    con.Open();
    	    using (var cmd = new SqlCommand(
    		"select UserId from Users where username=@username and password=@password",
    		con))
    	    {
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
    			var id = cmd.ExecuteScalar();
    			Session["ID"] = id;
    
    	    }
    	}
    }
