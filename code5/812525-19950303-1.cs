    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row = ((DataRowView)e.Row.DataItem).Row;  // if this doesn't work use the debugger to see the real type
            TextBox txtDateTo = (TextBox) e.Row.FindControl("txtDateTo");
            DateTime? byPassDateTo = row.Field<DateTime?>("ByPassDateTo");
            txtDateTo.Text = byPassDateTo.HasValue ? byPassDateTo.ToShortDateString() : "";
        }
    }
