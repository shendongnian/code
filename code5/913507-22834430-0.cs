    protected void OnDataBound(object sender, EventArgs e)
    
    {
    
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
    
        TableHeaderCell cell = new TableHeaderCell();
    
        cell.Text = "Your text1";
    
        cell.ColumnSpan = 3;
    
        row.Controls.Add(cell);    
    
        cell = new TableHeaderCell();
    
        cell.ColumnSpan = 3;
    
        cell.Text = "Your text2";
    
        row.Controls.Add(cell);
    
        GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
    
    }
