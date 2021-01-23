    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e){
    if (e.CommandName.Equals("Sort"))
    {
        FilterExpression = e.CommandArgument.ToString() + " LIKE '%" + txtCaseNumber.Text + "%'";
        BindGridView();
    }}
