    private DataTable oData = null;
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (oData == null && e.Row.DataItem != null)
        {
            oData = (e.Row.DataItem as DataRowView).Row.Table;
        }
    }
