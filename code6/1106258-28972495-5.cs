    List<DataGridViewCell> coloredCells = new List<DataGridViewCell>();
    private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
        if (coloredCells.Contains(cell) ) coloredCells.Remove(cell);
        else coloredCells.Add(cell);
        cell.Style.BackColor = coloredCells.Contains(cell) ? Color.Pink : Color.White;
    }
