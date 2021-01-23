       if (!PostBack)
     {
          string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;
          string sql = "update users Set uname=@Uname,ushortname=@Ushortname,pswd=HASHBYTES('MD5',@Pswd) where ucode=@UCODE";    
          using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
          {
            conn.Open();
	        cmd.Parameters.AddWithValue("@Uname",txtUserName.Text );
	        cmd.Parameters.AddWithValue("@Ushortname",txtUserShortName.Text );
	        cmd.Parameters.AddWithValue("@Pswd",txtPassword.Text );
	        cmd.Parameters.AddWithValue("UCODE", UCODE);
	        cmd.ExecuteNonQuery();
            conn.Close();
	        cmd.Dispose();
         }
      }
    
