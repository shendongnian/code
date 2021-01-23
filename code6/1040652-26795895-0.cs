    public Form1()
        {
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
        }
    void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex > 0)
                dataGridView1.Rows[e.RowIndex - 1].DefaultCellStyle.BackColor = Color.White;
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
        }
