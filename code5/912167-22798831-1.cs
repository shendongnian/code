    int lastCounter = 0;
    
    protected void DropDownListAddNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        ++lastCounter;
        Session["selection" + lastCounter] = DropDownListAddNumber.Items
                                            .FindByValue(DropDownListAddNumber.SelectedValue);
    }
    
    // you can access last value as
    // var lastSelectedValue = Session["selection" + lastCounter];
