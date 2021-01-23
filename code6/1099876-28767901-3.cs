    private void DGV_Points_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        DataGridViewCell cell = DGV_Points[e.ColumnIndex, e.RowIndex];
        cell.Tag = cell.Value != null ? cell.Value : "";
    }
    private void DGV_Points_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCell cell = DGV_Points[e.ColumnIndex, e.RowIndex];
        if (cell.Tag != null && cell.Tag.ToString() != cell.Value.ToString()) 
            cell.Style.ForeColor = Color.Red;
    }
