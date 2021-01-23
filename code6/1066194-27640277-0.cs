    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        if(/*row matches search pattern*/)
        {
            row.CssClass = "HighlightedRow";
        }
    }
