    AllCells	The column width adjusts to fit the contents of all cells in the column, including the header cell.
    AllCellsExceptHeader	The column width adjusts to fit the contents of all cells in the column, excluding the header cell.
    DisplayedCells	The column width adjusts to fit the contents of all cells in the column that are in rows currently displayed onscreen, including the header cell.
    DisplayedCellsExceptHeader	The column width adjusts to fit the contents of all cells in the column that are in rows currently displayed onscreen, excluding the header cell.
----------
    this.DataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
    this.DataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
    this.DataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
