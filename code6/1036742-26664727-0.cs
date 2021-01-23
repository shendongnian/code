    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           string datetimeadded = DataBinder.Eval(e.Row.DataItem, "datetime_added").ToString();
           // or you can use the cell index to reference the boundfield like below
           string datetimeadded = e.Row.Cells[1].Text;
        }
    }
