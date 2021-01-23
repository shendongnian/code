    protected void GridViewVehicles_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
                {
                    //Get the drop-down datasource and perform databinding
                }
            }
    
            protected void GridViewVehicles_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                DropDownList ddlVehicles = GridViewVehicles.Rows[e.RowIndex].FindControl("ddlVehicles") as DropDownList;
    
                if (ddlVehicles != null)
                {
                    string selectedValue = ddlVehicles.SelectedValue;
                }
            }
