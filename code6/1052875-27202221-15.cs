    for (int i = 0; i <  dict.Keys.Count; i++)
    {
        string state = dict.Keys.ElementAt(i);
        string city1 = dict[state][0].ToString();
        dataGridView1.Rows.Add();
        DataGridViewComboBoxCell stateCell = 
                                (DataGridViewComboBoxCell)(dataGridView1.Rows[i].Cells[0]);
        stateCell.Items.AddRange(dict.Keys.ToArray());
        stateCell.Value = state;
        DataGridViewComboBoxCell cityCell = 
                                (DataGridViewComboBoxCell)(dataGridView1.Rows[i].Cells[1]);
        cityCell.Items.AddRange(dict[state].ToArray());
        cityCell.Value = city1;
    }
