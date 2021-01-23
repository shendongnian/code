    if (e.Row.RowType == DataControlRowType.DataRow)
    {
    	phListContainer = (PlaceHolder)e.Row.FindControl(phListContainer);
    	
    	if (phListContainer != null)
    	{
    		//Adding a DropDownList
    		var cmbIndexName = new DropDownList();
    		cmbIndexName.DataSource = _Indexes;
    		cmbIndexName.DataTextField = "IndexName";
    		cmbIndexName.DataValueField = "IndexId";
    		cmbIndexName.DataBind();
    		cmbIndexName.SelectedValue = grdIndexGroupMap.DataKeys[e.Row.RowIndex].Values[1].ToString();
    		
    		phListContainer.Controls.Add(cmbIndexName);
    		
    		// OR
    		
    		//Adding a CheckBoxList;
    		cmbIndexName = new CheckBoxList();
    		cmbIndexName.DataSource = _Indexes;
    		cmbIndexName.DataTextField = "IndexName";
    		cmbIndexName.DataValueField = "IndexId";
    		cmbIndexName.DataBind();
    		
    		phListContainer.Controls.Add(cmbIndexName);
    	}
    }
