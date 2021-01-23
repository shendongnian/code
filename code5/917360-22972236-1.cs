    protected void CreateRow(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {           
            GridView gridView = (GridView)sender;
            GridViewRow row = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableCell th = new TableHeaderCell();
            th.HorizontalAlign = HorizontalAlign.Center;
            th.ColumnSpan = UserGV.Columns.Count;
            th.ForeColor = Color.White;
            th.BackColor = Color.SteelBlue;
            th.Font.Bold = true;
            th.Text = "Manage Users";
            row.Cells.Add(th);
    
            gridView.Controls[0].Controls.AddAt(0, row);
        }
    }
