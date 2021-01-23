      SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
    
    
        Dataset dsresult = cmd.ExecuteDataset();
       If(dsResult !=null)
       {
         if(dsResult.Rows.count>0) 
        {
        drClient.Enabled = true;
        drClient.DataSource = dsResult.Tables[0] ;
        drClient.DataTextField = Convert.ToString(ds.Tables[0].Columns["cname"]);
        drClient.DataValueField = ds.Tables[0].Columns["clientID"] ;
        drClient.DataBind();
   
        }
 
       }  
   
