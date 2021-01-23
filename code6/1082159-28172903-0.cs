    DataGridView doesn't have row double click event. But you can try cell double click event instead as following:
    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = "";
            value = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
        }
