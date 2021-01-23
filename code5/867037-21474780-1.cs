    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
         DropDownList ddl = (DropDownList)sender;
         GridViewRow row = (GridViewRow)ddl.Parent.Parent;
         int idx = row.RowIndex;
         // TextBox txtECustCode = (TextBox)row.Cells[0].FindControl("txtECustCode");
