    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1)
           {
                bool val = (bool)dataGridView1.SelectedCells[0].Value;
                MessageBox.Show(val.ToString());
           }
    }
