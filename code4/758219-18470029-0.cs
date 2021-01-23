    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
        int x = int.Parse(ddlClient.SelectedValue);
    
        DataSet ds = GetRowFromDatabase( x);
    
        //the first time initialize the session variable
        if(Session["old"] == null)
        {
            Session["old"] = ds;
        }
        else
        { 
            ((DataSet)Session["old"]).Merge(ds);
        }
    
        gridview.DataSource = Session["old"] ;
        gridview.DataBind();
    
    }
