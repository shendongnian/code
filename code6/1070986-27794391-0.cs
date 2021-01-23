    private void btnLogin_Click(object sender, EventArgs e)
    {
        // define query - and **ALWAYS** use parameters!
    	string query = "SELECT COUNT(*) FROM dbo.MsUser WHERE username = @UserName AND password = @password);";
    	
    	// set up connection and command
        using (SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ProgII Project\MoneyManager\MoneyManager\MsUser.mdf;Integrated Security=True;User Instance=True"))
    	using (SqlCommand cmd = new SqlCommand(query, cn))
    	{
            // define parameters and provide values
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = txtUserName.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = txtPassword.Text;
    
    		// open connection, execute command, close connection
    		cn.Open();
    		var result = cmd.ExecuteScalar();
    		cn.Close();
    
    		// if result is not null and can be converted to an int....
    		if(result != null)
    		{
    		    int userCount;
    			
    			if(int.TryParse(result.ToString(), out userCount))
    			{
    			    // OK, you have a good value - if it's > 0, your user entry exists....
    				if (userCount > 0)
    				{
    				    // success - user exists with password
    				}
    				else 
    				{
    				    // no success - no such entry
    				}
    			}
    			else
    			{
    			   // you didn't get a numeric value......
    			}
    		}
    		else
    		{
    			// you didn't get any value......
    		}
        }
    }
