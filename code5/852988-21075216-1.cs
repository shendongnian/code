    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells["Dependencies"];
            [Plugin_Type] entry = dataGridView1.Rows[i].DataBoundItem as [Plugin_Type];
            comboCell.DataSource = entry.[YOUR_PROPERTY];
        }
    }
