    private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
        _oldValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
    }
    private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        _newValue = dataGridView[e.ColumnIndex, e.RowIndex].Value;
        if (_newValue != _oldValue)
        {
            // YOUR LOGIC SHOULD START FROM HERE
        }
    }
