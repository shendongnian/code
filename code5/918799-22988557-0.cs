    DataGridView1.Rows.Add(val[0], val[1], val[2], va[3], val[4]);
    DataGridViewComboBoxCell cb= new DataGridViewComboBoxCell();
    cb.MaxDropDownItems = 5;
    cb.Items.Add(DataGridView1.Rows[DataGridView1.Rows.Count - 1].Cells[3].Value.ToString());
    cb.Value = DataGridView1.Rows[DataGridView1.Rows.Count - 1].Cells[3].Value.ToString();
    DataGridView1.Rows[DataGridView1.Rows.Count - 1].Cells[3] = cb;
    
