    Using (SqlConnection sqlconn=new  
    SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString))
      {
        DataSet ds=new DataSet()
        byte[] Context_Info;
        sqlconn.open();
        
         string sql1 = "Select cast('UserID='+CONVERT(varchar(10),@UserID)
         +REPLICATE(' ',128) as varbinary(128)) Context_Info";
         string sql2 = "do Insert / Update / Delete that will fire the trigger";
    
        using (SqlCommand command = new SqlCommand(sql1,sqlconn))
        {
            //Command 1
            using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
                da.Fill(ds);
                Context_Info=(byte[])ds.Tables[0].Rows[0]["Context_Info"];
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
