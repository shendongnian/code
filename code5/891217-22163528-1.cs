    protected void grdProductPrices_OnRowUpdating(object aSender, GridViewUpdateEventArgs aEventArgs)
    {
        DropDownList cmbProductTypes = grdProductPrices.Rows[aEventArgs.RowIndex].FindControl("ddlProductType") as DropDownList;
        if (cmbProductTypes != null)
        {
            e.NewValues["Type"] = cmbProductTypes.SelectedValue;
        }
    }
