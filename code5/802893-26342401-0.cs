    using System.Web.UI.HtmlControls;
    public static Table DataTableToHTMLTable(DataTable dt)
    {
        Table tbl = new Table();
        TableRow tr = null;
        TableCell cell = null;
        int rows = dt.Rows.Count;
        int cols = dt.Columns.Count;
        for (int i = 0; i < rows; i++)
        {
            tr = new TableRow();
            for (int j = 0; j < cols; j++)
            {
                cell = new TableCell();
                cell.Text = dt.Rows[i][j].ToString();
                tr.Cells.Add(cell);
            }
            tbl.Rows.Add(tr);
        }
        return tbl;
    }
