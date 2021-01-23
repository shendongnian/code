    protected void Button1_Click (Object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "1")
        {
            Response.Redirect("default.aspx");
        }
        else if (DropDownList1.SelectedItem.Text == "2")
        {
            Response.Redirect("default.aspx");
        }
    }
