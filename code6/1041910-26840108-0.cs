    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
    col.Name = "cboColumn";
    col.Items.Add("A");
    col.Items.Add("B");
    dgv.Columns.Add(col);
    if (dgv.CurrentRow != null)
        dgv.CurrentRow.Cells[0].Value = "A";
