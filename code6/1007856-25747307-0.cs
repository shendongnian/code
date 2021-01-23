    using (SqlConnection connection = new SqlConnection(connString))
    {
        //Get Parent Task
        SqlCommand command = new SqlCommand(queryStringParent, connection);
        connection.Open();
    
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        
        if (!string.IsNullOrEmpty(fkobjectid) && fkobjectid != "&nbsp;")
        {
            da.Fill(ds);
    
            gvParentTasks.DataSource = ds.Tables[0];
            gvParentTasks.DataBind();
        }
    }
