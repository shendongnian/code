    protected void btn_Clicked(object sender, EventArgs e)
    {
        int line = ((GridViewRow)((Button)sender).Parent.Parent).RowIndex;
        DropDownList drp = ((DropDownList)TitleView.Rows[line].FindControl("TitleList"));
        //Continue the method
    }
