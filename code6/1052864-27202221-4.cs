    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        setCities(e.RowIndex, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
    }
    void setCities(int row, string state)
    {
        DataGridViewComboBoxCell cityCell = 
                                (DataGridViewComboBoxCell)(dataGridView1.Rows[row].Cells[1]);
        cityCell.Items.Clear();
        cityCell.Items.AddRange(dict[state].ToArray());
        cityCell.Value = cityCell.Items[0];
    }
