    <asp:Table ID="Table1" runat="server">
    
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int RowIndex = 0; RowIndex < 4; RowIndex++)
        {
            TableRow NewRow = new TableRow();
    
            for (int ColumnIndex = 0; ColumnIndex < 4; ColumnIndex++)
            {
                TableCell NewCell = new TableCell();
                NewCell.Text = "aaa";
                NewRow.Cells.Add(NewCell);
            }
            Table1.Rows.Add(NewRow);
        }
    
        Table1.Rows[3].Cells[3].Text =  "Hello World!";
    }
