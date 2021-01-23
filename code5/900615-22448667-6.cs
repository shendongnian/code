    protected void DropDownDataBound(object sender, EventArgs e)
    {
        //set value here.
        //DropDownList1.SelectedItemIndex = 5; //this will show the 6th item
        var itm = DropDownList1.Items.FindByValue("BONAP");
        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(itm);
    }
