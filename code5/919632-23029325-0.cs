        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            MessageBox.Show("Row deleted");
            if ((dataGridView1.SelectedRows.Count==0)
                || ((dataGridView1.SelectedRows.Count == 1)
                &&(dataGridView1.SelectedRows[0].IsNewRow)))
            {
                MessageBox.Show("Set of rows deleted");
            }
        }
