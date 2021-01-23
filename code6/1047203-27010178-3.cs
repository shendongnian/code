    if (!PostBack)
    {
       string databaseconnectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;
       string sql = "update users Set uname=@Uname,ushortname=@Ushortname,pswd=HASHBYTES('MD5',@Pswd) where ucode=@UCODE";    
       using (SqlConnection conn = new SqlConnection(databaseconnectionstring))
       {
         conn.Open();
         using (SqlCommand cmd= new SqlCommand())
         {
            cmd.CommandText=sql;
            cmd.Connection=databaseconnectionstring;
	        cmd.Parameters.AddWithValue("@Uname",txtUserName.Text );
	        cmd.Parameters.AddWithValue("@Ushortname",txtUserShortName.Text );
	        cmd.Parameters.AddWithValue("@Pswd",txtPassword.Text );
	        cmd.Parameters.AddWithValue("@UCODE", UCODE);
	        cmd.ExecuteNonQuery();
            conn.Close();
	        cmd.Dispose();
         }
      }
    }
    
