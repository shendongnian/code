    using System.Data;
    using System.Web.UI.HtmlControls;
    public static Table DataTableToHTMLTable(DataTable dt, bool includeHeaders)
    {
        Table tbl = new Table();
        TableRow tr = null;
        TableCell cell = null;
        int rows = dt.Rows.Count;
        int cols = dt.Columns.Count;
        if (includeHeaders)
        {
            TableHeaderRow htr = new TableHeaderRow();
            TableHeaderCell hcell = null;
            for (int i = 0; i < cols; i++)
            {
                hcell = new TableHeaderCell();
                hcell.Text = dt.Columns[i].ColumnName.ToString();
                htr.Cells.Add(hcell);
            }
            tbl.Rows.Add(htr);
        }
        
        for (int j = 0; j < rows; j++)
        {
            tr = new TableRow();
            for (int k = 0; k < cols; k++)
            {
                cell = new TableCell();
                cell.Text = dt.Rows[j][k].ToString();
                tr.Cells.Add(cell);
            }
            tbl.Rows.Add(tr);
        }
        return tbl;
    }
