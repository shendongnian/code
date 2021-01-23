    using(SqlConnection Sqlcon = new SqlConnection(ConnectionString))
     { 
      SqlCommand cmd = new SqlCommand("dbo.Check_role", sqlcon);
    
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserName", txt_Username.Text);
        cmd.Parameters.AddWithValue("@Password", txt_password.Text);
        
        cmd.Parameters.Add("@IsValid", SqlDbType.Int);
        cmd.Parameters["@IsValid"].Direction = ParameterDirection.Output;
        con.Open();
        
        cmd.ExecuteNonQuery();
        
        string LoginStatus = cmd.Parameters["@IsValid"].Value.ToString();
        
         if (LoginStatus == 1 || LoginStatus == 2)
    	 {
              
              if(LoginStatus == 2)
              {
                // if a user is admin do stuff here
              }
              else
              {
               // if a user is NOT admin do stuff here
              }
    		 MessageBox.Show("Welcome " + txt_Username.Text);
    	 }
    	 else
    	 {
    		 MessageBox.Show("The Username or Password you entered is incorrect. Please try again");
    	 }
     }
