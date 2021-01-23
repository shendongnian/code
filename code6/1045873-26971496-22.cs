    Using (SqlConnection sqlconn=new  
    SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
      {
        
        sqlconn.open();
        
         string sql1 = "cast('UserID='+CONVERT(varchar(10),@UserID)
         +REPLICATE(' ',128) as varbinary(128))";
         string sql2 = "do Insert / Update / Delete that will fire the trigger";
    
        using (SqlCommand command = new SqlCommand(sql1,sqlconn))
        {
            //Command 1
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // reader.Read ContextInfo bytes here.
            }
    
        } 
       using (Sqlcommand cmd=new Sqlcommand(sql1,sqlConn))
       {
          //Pass both context info and User id
         cmd.Parameters.AddWithValue("@ContextInfo ",ContextInfo);
         cmd.Parameters.AddWithValue("@UserID",UserID);
         cmd.ExceuteNonQuery();
       } 
    }
