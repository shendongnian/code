    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 1)
        {
            String cellValue;
            cellValue = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            var form2 = new Form2(cellValue);
            this.Hide();
            form2.Show();
        }
    }
