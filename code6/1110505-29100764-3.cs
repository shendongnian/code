    private DataTable oData = null;
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Data == null && e.Row.DataItem != null)
        {
            oData = (e.Row.DataItem as DataRowView).Row.Table;
            // some gui-adaption like visibility, text, ...
        }
    }
