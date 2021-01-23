    protected void grdDummy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "Delete")
    	{
    		string docid = e.CommandArgument.ToString();
    		//find field by documentId and remove it from list
    		data.Remove(data.Find(o => o.DocumentId == docid));
    		
    		ViewState["_data"] = data;
    		
    		//rebind grid
    		grdDummy.DataSource = data;
    		grdDummy.DataBind();
    		e.Handled = true;
    	}
    }
