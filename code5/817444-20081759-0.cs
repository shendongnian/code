    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if ( e.Item.ItemType == ListItemType.Item ) 
    	{
    		DropDownList ddldrop = e.Item.FindControl("DropDownList4") as DropDownList;
    		HiddenField hfDepartmentId = Repeater2.FindControl("hfDepartmentId") as HiddenField;
    
    		if (ddldrop != null && hfDepartmentId != null && hfDepartmentId.Value != 
    		string.Empty && hfDepartmentId.Value.Trim() != "3")
    		{
    			ddldrop.SelectedValue = hfDepartmentId.Value.Trim();
    			ddldrop.Enabled = false;
    		}
    	}
    }
