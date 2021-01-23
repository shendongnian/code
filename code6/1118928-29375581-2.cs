    protected void FormViewClient_DataBound(object sender, EventArgs e)
    {
	    ...
	    DropDownList ddl = FormViewClient.FindControl("ddlStatus") as DropDownList;
        TextBox txtBx = FormViewClient.FindControl("txtBxStatus") as TextBox;
        if (ddl != null && txtBx != null)
        { ddl.SelectedValue = txtBx.Text; }
	    ...
    }
   
