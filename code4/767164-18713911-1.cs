    if (this.dataGridView1.SelectedRows.Count > 0)
    {
        StringBuilder ClipboardBuillder = new StringBuilder();
        foreach (DataGridViewRow Row in dataGridView1.SelectedRows)
        {
            foreach (DataGridViewColumn Column in dataGridView1.Columns)
            {
               ClipboardBuillder.Append(Row.Cells[Column.Index].FormattedValue.ToString() + " ");
            }
            ClipboardBuillder.AppendLine();
        }
    
        Clipboard.SetText(ClipboardBuillder.ToString());
    }
