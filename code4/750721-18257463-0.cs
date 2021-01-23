    // new form field for caching
    private List<DataGridViewRow> _addedRowsCache = new List<DataGridViewRow>();
    private void dataGridView1_RowsAdded(object sender,
        DataGridViewRowsAddedEventArgs e)
    {
        for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
        {
            _addedRowsCache.Add(dataGridView.Rows[i]);
        }
    }
