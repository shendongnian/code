    Protected function repeater1_ItemCreated(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          CheckBoxList checkBoxValues = (CheckBoxList)e.Item.FindControl("CheckBoxValues");
          String selectedValue = checkBoxValues.SelectedValue;
          //Do your stuff ...
        }
    }
