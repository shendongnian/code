    public object CurrentCellValue;
    private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        CurrentCellValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
    }
    private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        var cellVaue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
        if (!ValidateTime(cellVaue.ToString()))
            dataGridView[e.ColumnIndex, e.RowIndex].Value = CurrentCellValue;
    }
