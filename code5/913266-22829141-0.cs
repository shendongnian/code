    protected void GridViewHouzzPriceUpdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       GridViewRow row = (GridViewRow)GridViewHouzzPriceUpdate.Rows[e.RowIndex];
       string updatePriceTo = ((TextBox)row.FindControl("TextBoxUpdatePriceTo")).Text;
       string Operation = ((DropDownList)row.FindControl("DropDownListOperation")).SelectedValue;
       string updateType = ((DropDownList)row.FindControl("DropDownUpdateType")).SelectedValue;
       //Reset the edit index.
       GridViewHouzzPriceUpdate.EditIndex = -1;
      //update data source here 
       UpdateDataSource(updatePriceTo, Operation, updateType); 
      //Bind data to the GridView control.
      bindGridViewHouzzPriceUpdate();
    }
