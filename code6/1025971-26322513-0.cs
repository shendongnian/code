    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
    cell.Items.Add("Sth1");
    cell.Items.Add("Sth2");
    DataGridViewRow row = new DataGridViewRow(); 
                
    if (dataGridView1.Columns.Count == 0)
        dataGridView1.Columns.Add(col);
    row.Cells.Add(cell);
    dataGridView1.Rows.Add(row);
