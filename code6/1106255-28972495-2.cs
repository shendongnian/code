    private void DGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        DataGridViewCell cell = DGV[e.ColumnIndex, e.RowIndex];
        cell.Selected = !cell.Selected;
        cell.Style.BackColor = cell.Selected ? Color.Pink : Color.White;
    }
