    int num = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
            CheckCount(isChecked);
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
            CheckCount(isChecked);
        }
        private void CheckCount(bool isChecked)
        {
            if (isChecked)
            {
                num++;
            }
            else
            {
                num--;
            }
            labelSelectedSum.Text = "Selected Items: " + num;
        }
