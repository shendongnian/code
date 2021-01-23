    protected void Gridview1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView) e.Row.DataItem).Row;
            Label WEDateLabel = (Label) e.Row.FindControl("WEDateLabel");
            DateTime weDate = DateTime.Parse(row.Field<string>("WEDate"));
            WEDateLabel.Text = weDate.ToShortDateString();
        }
    }
