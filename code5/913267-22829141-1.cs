    protected void GridViewHouzzPriceUpdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       GridViewRow row = (GridViewRow)GridViewHouzzPriceUpdate.Rows[e.RowIndex];
       string updatePriceTo = string.Empty;
       string Operation = string.Empty;
       string updateType = string.Empty;
    
       TextBox txtUpdatePriceTo = row.FindControl("TextBoxUpdatePriceTo") as TextBox;
       if(txtUpdatePriceTo != null)
         updatePriceTo = txtUpdatePriceTo.Text;
    
       DropDownList ddlOperation = row.FindControl("DropDownListOperation") as DropDownList;
       if(ddlOperation != null)           
        Operation = ddlOperation.SelectedValue;
       DropDownList ddlDropDownUpdateType = row.FindControl("DropDownUpdateType") as DropDownList;
       if(ddlDropDownUpdateType != null)           
        updateType = ddlDropDownUpdateType .SelectedValue;
    
       //Reset the edit index.
       GridViewHouzzPriceUpdate.EditIndex = -1;
      if(updatePriceTo != string.Empty && Operation != string.Empty && updateType != string.Empty)
       //update data source here 
       UpdateDataSource(updatePriceTo, Operation, updateType); 
      //Bind data to the GridView control.
      bindGridViewHouzzPriceUpdate();
    }
