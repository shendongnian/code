    if(!DropDownList1.Items.FindByValue(DropDownList1.SelectedValue))
        {
            DropDownList1.Items.Add(DropDownList1.SelectedValue);
        }
    
    if(!DropDownList1.Items.FindByText(DropDownList1.SelectedItem.Text))
        {
            DropDownList1.Items.Add(DropDownList1.SelectedValue);
        }
