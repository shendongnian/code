                pol.Open();
            SqlDataAdapter list_adapter = new SqlDataAdapter("SELECT value FROM box ORDER BY value ASC", pol);
            DataTable list_dt = new DataTable();
            list_adapter.Fill(list_dt);
            string[] items = new string[list_dt.Rows.Count];
            for (int i = 0; i < list_dt.Rows.Count; i++)
            {
                items[i] = list_dt.Rows[i][0].ToString();
                //MessageBox.Show(list_dt.Rows[i][0].ToString());
            }
            pol.Close();
            int index = 2;
            for (int i = 1; i <= number_of_columns; i++)
            {
                dataGridView1.Columns.Insert(index, new DataGridViewComboBoxColumn
                {
                    Name = "name_" + i,
                    HeaderText = "Name " + i,
                    DataSource = items
                });
                index = index + 1;
            }
                pol.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM table ORDER BY name ASC", pol);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i].ItemArray[0];
                dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i].ItemArray[1];
                int index_2 = 2;
                for (int j = 1; j <= number_of_columns; j++)
                {
                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[index_2];
                    cell.Value = dt.Rows[i].ItemArray[index_2];
                    index_2 = index_2 + 1;
                }
                
            }
            pol.Close();
