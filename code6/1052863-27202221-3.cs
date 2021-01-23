    for (int i = 0; i < dt.Rows.Count; i++)
    {
        string state = dt.Rows[i][0].ToString();
        string city = dt.Rows[i][1].ToString();
        dataGridView1.Rows.Add();
        DataGridViewComboBoxCell stateCell = 
                                (DataGridViewComboBoxCell)(dataGridView1.Rows[i].Cells[0]);
        stateCell.Items.AddRange(dict.Keys.ToArray());
        stateCell.Value = state;
        DataGridViewComboBoxCell cityCell = 
                                (DataGridViewComboBoxCell)(dataGridView1.Rows[i].Cells[1]);
        cityCell.Items.AddRange(dict[stateCell.Value.ToString()].ToArray());
        cityCell.Value = city;
    }
