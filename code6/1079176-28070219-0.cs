    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        var DropDownList1 = (DropDownList)sender;
        var DropDownList2 = (DropDownList)sender;
        var DropDownList3 = (DropDownList)sender;
        string DDL1 = ((DropDownList)DropDownList1.NamingContainer.FindControl("DropDownList1")).SelectedValue;
        string DDL2 = ((DropDownList)DropDownList2.NamingContainer.FindControl("DropDownList2")).SelectedValue;
        string DDL3 = ((DropDownList)DropDownList3.NamingContainer.FindControl("DropDownList3")).SelectedValue;
    }
