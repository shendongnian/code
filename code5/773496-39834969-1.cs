      protected void Grid_ItemDataBound(object sender, GridItemEventArgs e)  
        {
        string DurationName;
        if (e.Item is GridDataItem)
        {
            GridDataItem myGridItem = (GridDataItem)e.Item;
            //Changing the DurationName field to Combobox in EDITMODE
            if (myGridItem.IsInEditMode)
            {
                GridEditableItem edititem = e.Item as GridEditableItem;
                int userId = Convert.ToInt16(edititem.GetDataKeyValue("RowNumber"));
                RadComboBoxItem selectedItem = new RadComboBoxItem(); 
                RadComboBox combo = (RadComboBox)myGridItem["DurationType"].FindControl("colname");
                DurationName= DataBinder.Eval(myGridItem.DataItem, "DurationType").ToString();
                combo.DataSource = roles.GetRoles();
                combo.DataTextField = "DurationType";
                combo.DataValueField = "DurationID";
                combo.DataBind();
                selectedItem = combo.FindItemByText(DurationName);
                combo.SelectedIndex = selectedItem.Index;
            }
          }
        }
 
