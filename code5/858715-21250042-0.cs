    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddl = (DropDownList)sender;
        var row = (GridViewRow)(ddl.NamingContainer);
        var lb = (LinkButton)row.FindControl("LinkButton4");
        
        if (ddl.SelectedValue == "Upload")
        {
            lb.PostBackUrl = "preprod_design.aspx#edit";
        }
        if (ddl.SelectedValue == "Download")
        {
            ....
        }
    }    
