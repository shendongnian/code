    if (Page.PreviousPage != null)
    {
        DropDownList ddl1 = 
            (DropDownList)Page.PreviousPage.FindControl("DropDownList1");
        if (ddl1 != null)
        {
            Label1.Text = ddl1.SelectedItem.Text; //your logic
        }
    }
