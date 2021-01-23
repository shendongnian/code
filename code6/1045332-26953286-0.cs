    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        // Populate dropdown with column names
        if(e.Row.RowType != DataControlRowType.Header) return; //only continue if this is hdr row
        ddColumnSearch.Items.Clear();
        foreach (TableCell cell in e.Row.Cells)
        {
            ddColumnSearch.Items.Add(new ListItem(cell.Text));
        }
    }
