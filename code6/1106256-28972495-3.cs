    List<DataGridViewCell> coloredCells = new List<DataGridViewCell>();
    private void DGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        DataGridViewCell cell = DGV[e.ColumnIndex, e.RowIndex];
        if (coloredCells.Contains(cell) ) coloredCells.Remove(cell);
        else coloredCells.Add(cell);
        cell.Style.BackColor = coloredCells.Contains(cell) ? Color.Pink : Color.White;
    }
