        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                string ID, ItemCode, ProductName, Amount, qty = comboBox2.Text, Total;
                ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value + "";
                ItemCode = dataGridView1.Rows[e.RowIndex].Cells[1].Value + "";
                ProductName = dataGridView1.Rows[e.RowIndex].Cells[2].Value + "";
                Amount = dataGridView1.Rows[e.RowIndex].Cells[3].Value + "";
                Total = (Convert.ToInt32(Amount) * Convert.ToInt32(qty)).ToString();
                DataTable table;
                if (dataGridView2.RowCount > 0)
                {
                    table = (DataTable)dataGridView2.DataSource;
                }
                else
                {
                    table = new DataTable();
                    table.Columns.Add("ID", typeof(int));
                    table.Columns.Add("ItemCode", typeof(string));
                    table.Columns.Add("ProductName", typeof(string));
                    table.Columns.Add("Amount", typeof(string));
                }
                table.Rows.Add(ID, ItemCode, ProductName, Total);
                dataGridView2.DataSource = table;
            }
        }
