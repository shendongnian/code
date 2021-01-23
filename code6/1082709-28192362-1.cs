        private void button1_Click(object sender, EventArgs e)
        {
            List<string> selectedRows = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string currentRow = string.Empty;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    currentRow += String.Format("{0} ", cell.FormattedValue);
                }
                selectedRows.Add(currentRow);
            }
            for (int i = 0; i < selectedRows.Count; i++)
            {
                this.listBox1.Items.Add(selectedRows[i]);
            }
        }
