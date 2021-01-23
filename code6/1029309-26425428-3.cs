    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grid = (GridView)sender;
            int indexOfColumn = grid.GetColumnIndex("ColumnName");
            // for example to access the correct index in e.Row.Cells
            e.Row.Cells[indexOfColumn].Text = "Hello";
        }
    }
