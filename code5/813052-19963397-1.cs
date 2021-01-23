        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            textBox9.Text = CellSum().ToString();
        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
                textBox9.Text = CellSum().ToString();
        }
        private double CellSum()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                double d = 0;
                Double.TryParse(dataGridView2.Rows[i].Cells[5].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }
