    protected void DropDownList1_OnIndexChanged(object Source, EventArgs args)
    {
        
        if (DropDownList.SelectedItem.Text == "Visa")
        {
            RegularExpression1.ValidationExpression = "^(4)([0-9]{15})$";
            else
            RegularExpression1.ValidationExpression = "^(5[1-5])([0-9]{14})$";
        }
    }
