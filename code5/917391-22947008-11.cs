    protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
             var tbl = (DataTable)((Repeater)sender).DataSource;
             SetHeaderValue(e.Item, "litHeader1", tbl, 0);
             SetHeaderValue(e.Item, "litHeader2", tbl, 1);
             SetHeaderValue(e.Item, "litHeader3", tbl, 2);
             SetHeaderValue(e.Item, "litHeader4", tbl, 3);
        }
    }
    private void SetHeaderValue(RepeaterItem item, string litId, DataTable tbl, int colIndex)
    {
        var lit = item.FindControl(litId) as Literal;
        if (lit != null)
        {
            string headerText = 
                tbl.Columns.Count > colIndex ? tbl.Columns[colIndex].ColumnName : "Not set";
            lit.Text = headerText;
        }
    }
