    protected void cboDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
    	DropDownList cboDivision = gvAreas.Rows[gvAreas.EditIndex].FindControl("cboDivision") as DropDownList;
    	DropDownList cboBusinessUnit = gvAreas.Rows[gvAreas.EditIndex].FindControl("cboBusinessUnit") as DropDownList;
    
    	cboBusinessUnit.Items.Clear();
    
    	if (cboDivision.SelectedValue != null && !String.IsNullOrEmpty(cboDivision.SelectedValue))
    	{
    		var businessUnits = db.CDB_BusinessUnits.Where(b => b.DivisionID == Convert.ToInt32(cboDivision.SelectedValue)).OrderBy(b => b.Name);
    		cboBusinessUnit.DataSource = businessUnits;
    	}
    	else
    	{
    		var businessUnits = db.CDB_BusinessUnits.Where(b => b.DivisionID == null).OrderBy(b => b.Name);
    		cboBusinessUnit.DataSource = businessUnits;
    	}
    
    	cboBusinessUnit.DataBind();
    }
    
    protected void gvAreas_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    	DropDownList cboBusinessUnit = gvAreas.Rows[gvAreas.EditIndex].FindControl("cboBusinessUnit") as DropDownList;
    
    	if (cboBusinessUnit.SelectedValue != null && !String.IsNullOrEmpty(cboBusinessUnit.SelectedValue))
    	{
    		e.NewValues["BusinessUnitID"] = Convert.ToInt32(cboBusinessUnit.SelectedValue);
    	}
    	else
    	{
    		e.NewValues["BusinessUnitID"] = null;
    	}
    }
    
    protected void gvAreas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if ((e.Row.RowState & DataControlRowState.Edit) > 0)
    	{
    		CDB_Area area = e.Row.DataItem as CDB_Area;
    
    		if (area.BusinessUnitID != null)
    		{
    			DropDownList cboDivision = e.Row.FindControl("cboDivision") as DropDownList;
    			DropDownList cboBusinessUnit = e.Row.FindControl("cboBusinessUnit") as DropDownList;
    
    			if (area.CDB_BusinessUnit.DivisionID != null)
    			{
    				cboDivision.Items.FindByValue(area.CDB_BusinessUnit.DivisionID.ToString()).Selected = true;
    
    				var businessUnits = db.CDB_BusinessUnits.Where(b => b.DivisionID == area.CDB_BusinessUnit.DivisionID).OrderBy(b => b.Name);
    				cboBusinessUnit.DataSource = businessUnits;
    			}
    			else
    			{
    				var businessUnits = db.CDB_BusinessUnits.Where(b => b.DivisionID == null).OrderBy(b => b.Name);
    				cboBusinessUnit.DataSource = businessUnits;
    			}
    
    			cboBusinessUnit.DataBind();
    			cboBusinessUnit.Items.FindByValue(area.BusinessUnitID.ToString()).Selected = true;
    		}
    	}
    }
