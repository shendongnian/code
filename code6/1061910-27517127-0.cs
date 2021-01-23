    DataTable dtb = new DataTable("D");
    dtb.Columns.Add("C1");
    dtb.Rows.Add("A");
    dtb.Rows.Add("B");
    dtb.Rows.Add("C");
    dtb.Rows.Add("D");
    dtb.Rows.Add("E");
    dataGridView1.DataSource = dtb;
    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    if (dataGridView1.SelectedRows.Count > 0)
    {
        dataGridView1.Rows[0].Selected = false;
    }
