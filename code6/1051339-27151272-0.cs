    if (isNullOrEmpty(seardata)) 
    {   
    cmd = new SqlCommand(your query); 
    } 
    else 
    {  
     cmd = new SqlCommand(your other query); 
    }
        
    cmd.CommandType = CommandType.Text;
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds, "ss");
    gridrfqheader0.DataSource = ds.Tables["ss"];
    gridrfqheader0.DataBind();
