    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1)
           {
                bool val = (bool)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                MessageBox.Show(val.ToString());
           }
    }
