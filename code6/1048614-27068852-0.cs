    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int x;
            if (this.Visible && !int.TryParse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), out x))
            {
                MessageBox.Show("You have to enter digits only");
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = "";
            }
        }
