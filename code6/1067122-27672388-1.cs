    private void dgvView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        if (dgvView.Columns.Contains("ItemNumber"))
        {
			foreach (DataGridViewRow r in dgvView.Rows)
			{
			    r.Cells["ItemNumber"].Value = r.Index + 1;
			}
        }
    }
    
    private void dgvView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        if (dgvView.Columns.Contains("ItemNumber"))
        {
			foreach (DataGridViewRow r in dgvView.Rows)
			{
			    r.Cells["ItemNumber"].Value = r.Index + 1;
			}
        }
    }
