     protected void create_Click(object sender, EventArgs e)
    {
        Table dynamicTable = new Table();
        TableRow Row;
        TableCell Cell;
        int rowno=int.Parse(rows.Text);
        int cols=int.Parse(column.Text);
        for (int row = 0; row < rowno; row++)
        {
            Row = new TableRow();
            dynamicTable.Rows.Add(Row);
            for (int col = 0; col < cols; col++)
            {
                Cell = new TableCell();
                // adding radiobutton
                RadioButton rad = new RadioButton();
                rad.ID = "rad_" + col.ToString();
                Cell.Controls.Add(rad);
                Row.Cells.Add(Cell);
            }
        }
    }
