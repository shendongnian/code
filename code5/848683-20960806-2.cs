    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //Make sure the row is in edit mode to find controls in EditItemTemlates
    	if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState & DataControlRowState.Edit) > 0))
    	{
    
    		var ddl = GridView1.FindControl("selResolutionSeverity") as DropDownList;
    		if (ddl != null)
    		{
    
    			// Consider using parameterized query to prevent possible sql injection
    			string sSQL = @"SELECT ErrorTypeLookupID as Value, ErrorDescription as DisplayText
    							FROM BabelFish.dbo.ErrorTypeLookup (NOLOCK)
    							WHERE ErrorType = 'Severity' ";
    
    			DataSet DS = new DatabaseAccessing.DatabaseConnection().DS(sSQL);
    			ddl.DataSource = DS;
    			ddl.DataTextField = "DisplayText";
    			ddl.DataValueField = "Value";
    			ddl.DataBind();
    			ddl.Items.Insert(0, new ListItem("-- Select --", "0"));
    		}
    	}
    }
