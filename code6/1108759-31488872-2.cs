    protected void CerrTick_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCellCollection cell = e.Row.Cells;
            cell[0].Attributes.Add("data-th", "Movie Title");
            cell[1].Attributes.Add("data-th", "Genre");
            cell[2].Attributes.Add("data-th", "Year");
            cell[3].Attributes.Add("data-th", "Gross");
        } 
    }
