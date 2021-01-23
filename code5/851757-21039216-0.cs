    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        var rowIndex = e.RowIndex;
        var columnIndex = e.ColumnIndex; // = the cell the user clicked in
        // For example, fetching data from another cell
        var cell = dataGridView.Rows[rowIndex].Cells[columnIndex];
        // Depending on the cell's type* (see a list of them here: http://msdn.microsoft.com/en-us/library/bxt3k60s(v=vs.80).ASPX) you could cast it
        var castedCell = cell as DataGridViewTextBoxColumn;
        // Use the cell to perform action
        someActionMethod(castedCell.Property);
    }
