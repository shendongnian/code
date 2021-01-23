    // Event for formatting cells when rendering the grid
    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Some logic for determining which cell this is in the row
        if ((e.ColumnIndex == this.dataGridView1.Columns["SomeColumn"].Index))
        {
            // Get a reference to the cell
            DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            // Set the tooltip text
            cell.ToolTipText = "some text";
        }
    }
