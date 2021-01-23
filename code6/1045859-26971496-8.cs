    Using (SqlConnection Sqlconn=new  
    SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
      {
        
        Sqlconn.open();
        
         string sql1 = "cast('UserID='+CONVERT(varchar(10),@UserID)
         +REPLICATE(' ',128) as varbinary(128))";
         string sql2 = "do Insert / Update / Delete that will fire the trigger";
    
        using (SqlCommand command = new SqlCommand(sql1,connection))
        {
            //Command 1
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // reader.Read ContextInfo bytes here.
            }
    
        } 
     Using (Sqlcommand cmd=new Sqlcommand(sql1,SqlConn))
     {
       //Pass both context info and User id
       cmd.Parameters.AddWithValue("@ContextInfo ",ContextInfo);
       cmd.Parameters.AddWithValue("@UserID",UserID);
       cmd.ExceuteNonQuery();
     } 
    }
